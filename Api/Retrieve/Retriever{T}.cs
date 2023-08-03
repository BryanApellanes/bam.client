using Newtonsoft.Json;
using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class Retriever<T> : ApiCaller, IRetriever<T>
    {
        public Retriever(ApiConfig sdkConfig, IRetrieveRequestCreator<T> requestCreator, IDataManagementContext dataManagementContext) : base(sdkConfig, dataManagementContext)
        {
            //this.OAuthTokenProvider = new DefaultOAuthTokenProvider((Configuration)sdkConfig);
            this.ApiClient = new ApiClient(sdkConfig);
            this.RequestCreator = requestCreator;
            this.HttpMethod = HttpMethod.Get;
        }

        public IRetrieveRequestCreator<T> RequestCreator { get; set; }

        public Task<IRetrieveRequest<T>> CreateRequestAsync(IRetrieveArguments arguments)
        {
            return RequestCreator.GetRequestAsync(arguments);
        }

        public async Task<IRetrieveResult<T>> RetrieveAsync(IRetrieveArguments arguments)
        {
            if (ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }
           
            IRetrieveRequest<T> request = await CreateRequestAsync(arguments);
            Info($"Retrieving {typeof(T).Name}: {JsonConvert.SerializeObject(request.Data, Formatting.Indented)}");
            IRetrieveResult<T> result = new RetrieveResult<T>(arguments);
            try
            {
                RequestParameters requestParameters = await GetRequestParametersAsync(ApiConfig);
                requestParameters.Data = request.Data;
                HandlePathArguments(arguments, requestParameters);

                IResponse<T> response = await CallApiAsync<T>(ApiPathResolver.ResolvePath<T>(arguments), requestParameters, ApiConfig);
                if (IsSuccessCode(response))
                {
                    result.RetrievedObject = response.Data;
                }
                else
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
            }
            catch (Exception ex)
            {
                Error($"Exception creating {typeof(T).Name}: {ex.Message}", ex);
                result = new RetrieveResult<T>(arguments, ex);
            }

            return result;
        }

        async Task<IRetrieveRequest> IRetriever.CreateRequestAsync(IRetrieveArguments args)
        {
            return await CreateRequestAsync(args);
        }

        async Task<IRetrieveResult> IRetriever.RetrieveAsync(IRetrieveArguments args)
        {
            return await RetrieveAsync(args);
        }
    }
}
