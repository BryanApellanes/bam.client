using Newtonsoft.Json;
using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class Deleter<T> : ApiCaller, IDeleter<T>
    {
        public Deleter(ApiConfig sdkConfig, IDeleteRequestCreator<T> requestCreator, IDataManagementContext dataManagementContext): base(sdkConfig, dataManagementContext)
        {
            //this.OAuthTokenProvider = new DefaultOAuthTokenProvider((Configuration)sdkConfig);
            this.ApiClient = new ApiClient(sdkConfig);
            this.RequestCreator = requestCreator;
            this.HttpMethod = HttpMethod.Delete;
        }

        protected ApiConfig SdkConfig { get; set; }

        public IDeleteRequestCreator<T> RequestCreator { get; set; }

        public Task<IDeleteRequest<T>> CreateRequestAsync(IDeleteArguments args)
        {
            return RequestCreator.CreateRequestAsync(args);
        }

        public async Task<IDeleteResult<T>> DeleteAsync(IDeleteArguments args)
        {
            if (ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }
           
            IDeleteRequest<T> request = await CreateRequestAsync(args);
            Info($"Creating {typeof(T).Name}: {JsonConvert.SerializeObject(request.Data, Formatting.Indented)}");
            IDeleteResult<T> result = new DeleteResult<T>(args);
            try
            {
                RequestParameters requestParameters = await GetRequestParametersAsync(SdkConfig);
                requestParameters.Data = request.Data;
                HandlePathArguments(args, requestParameters);

                IResponse<T> response = await CallApiAsync<T>(ApiPathResolver.ResolvePath<T>(args), requestParameters, SdkConfig);
                if (IsSuccessCode(response))
                {
                    result.DeletedObject = response.Data;
                }
                else
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
            }
            catch (Exception ex)
            {
                Error($"Exception creating {typeof(T).Name}: {ex.Message}", ex);
                result = new DeleteResult<T>(args, ex);
            }

            return result;
        }

        async Task<IDeleteRequest> IDeleter.CreateRequestAsync(IDeleteArguments args)
        {
            return await CreateRequestAsync(args);
        }

        async Task<IDeleteResult> IDeleter.DeleteAsync(IDeleteArguments args)
        {
            return await DeleteAsync(args);
        }
    }
}
