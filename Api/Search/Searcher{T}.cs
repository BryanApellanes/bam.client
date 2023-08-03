using Newtonsoft.Json;
using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class Searcher<T> : ApiCaller, ISearcher<T>
    {
        public Searcher(ApiConfig sdkConfig, ISearchRequestCreator<T> requestCreator, IDataManagementContext dataManagementContext): base(sdkConfig, dataManagementContext)
        {
            this.ApiClient = new ApiClient(sdkConfig);
            this.RequestCreator = requestCreator;
            this.HttpMethod = HttpMethod.Get;
        }

        protected ApiConfig SdkConfig { get; set; }

        public ISearchRequestCreator<T> RequestCreator { get; set; }

        public Task<ISearchRequest<T>> CreateRequestAsync(ISearchArguments args)
        {
            return RequestCreator.CreateRequestAsync(args);
        }

        public async Task<ISearchResult<T>> SearchAsync(ISearchArguments arguments)
        {
            if (ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }
           
            ISearchRequest<T> request = await CreateRequestAsync(arguments);
            Info($"Creating {typeof(T).Name}: {JsonConvert.SerializeObject(request.Data, Formatting.Indented)}");
            ISearchResult<T> result = new SearchResult<T>(arguments);
            try
            {
                RequestParameters requestParameters = await GetRequestParametersAsync(SdkConfig);
                requestParameters.Data = request.Data;
                HandlePathArguments(arguments, requestParameters);

                IResponse<T> response = await ApiClient.PostAsync<T>(ApiPathResolver.ResolvePath<T>(arguments), requestParameters, SdkConfig);
                if (IsSuccessCode(response))
                {
                    result.SearchdObject = response.Data;
                }
                else
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
            }
            catch (Exception ex)
            {
                Error($"Exception creating {typeof(T).Name}: {ex.Message}", ex);
                result = new SearchResult<T>(arguments, ex);
            }

            return result;
        }

        async Task<ISearchRequest> ISearcher.CreateRequestAsync(ISearchArguments args)
        {
            return await CreateRequestAsync(args);
        }

        async Task<ISearchResult> ISearcher.SearchAsync(ISearchArguments args)
        {
            return await SearchAsync(args);
        }
    }
}
