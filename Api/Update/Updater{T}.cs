using Newtonsoft.Json;
using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class Updater<T> : ApiCaller, IUpdater<T>
    {
        public Updater(ApiConfig sdkConfig, IUpdateRequestCreator<T> requestUpdater, IDataManagementContext dataManagementContext) : base(sdkConfig, dataManagementContext)
        {
            this.ApiClient = new ApiClient(sdkConfig);
            this.RequestCreator = requestUpdater;
            this.HttpMethod = HttpMethod.Put;
        }

        public IUpdateRequestCreator<T> RequestCreator { get; set; }
        public Task<IUpdateRequest<T>> CreateRequestAsync(IUpdateArguments args)
        {
            return RequestCreator.CreateRequestAsync(args);
        }

        public async Task<IUpdateResult<T>> UpdateAsync(IUpdateArguments args)
        {
            if (ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }
           
            IUpdateRequest<T> request = await CreateRequestAsync(args);
            Info($"Updating {typeof(T).Name}: {JsonConvert.SerializeObject(request.ObjectToUpdate, Formatting.Indented)}");
            IUpdateResult<T> result = new UpdateResult<T>(args);
            try
            {
                RequestParameters requestParameters = await GetRequestParametersAsync(ApiConfig);
                requestParameters.Data = request.ObjectToUpdate;
                HandlePathArguments(args, requestParameters);

                IResponse<T> response = await CallApiAsync<T>(ApiPathResolver.ResolvePath<T>(args), requestParameters, ApiConfig);
                if (IsSuccessCode(response))
                {
                    result.UpdatedObject = response.Data;
                }
                else
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
            }
            catch (Exception ex)
            {
                Error($"Exception updating {typeof(T).Name}: {ex.Message}", ex);
                result = new UpdateResult<T>(args, ex);
            }

            return result;
        }


        async Task<IUpdateRequest> IUpdater.CreateRequestAsync(IUpdateArguments args)
        {
            return await CreateRequestAsync(args);
        }

        async Task<IUpdateResult> IUpdater.UpdateAsync(IUpdateArguments args)
        {
            return await UpdateAsync(args);
        }
    }
}
