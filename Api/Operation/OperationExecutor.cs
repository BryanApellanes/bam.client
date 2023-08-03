using Newtonsoft.Json;
using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client.Operation
{
    public class OperationExecutor : ApiCaller, IOperationExecutor
    {
        public OperationExecutor(ApiConfig sdkConfig, IOperationRequestCreator requestCreator, IDataManagementContext dataManagementContext) : base(sdkConfig, dataManagementContext)
        { }
        
        protected IOperationRequestCreator RequestCreator { get; set; }
        

        public Task<IOperationRequest> CreateRequestAsync(IOperationArguments arguments)
        {
            return RequestCreator.CreateRequestAsync(arguments);
        }

        public Task<IOperationRequest<T>> CreateRequestAsync<T>(IOperationArguments<T> arguments)
        {
            return RequestCreator.CreateRequestAsync<T>(arguments);
        }

        public async Task<IOperationResult> ExecuteAsync(IOperationArguments arguments)
        {
            if (ApiClient == null)
            {
                throw new ArgumentNullException(nameof(ApiClient));
            }

            IOperationRequest request = await CreateRequestAsync(arguments);
            Info($"Executin {arguments.OperationName}");
            OperationResult result = new OperationResult(arguments);
            try
            {
                RequestParameters requestParameters = await GetRequestParametersAsync(ApiConfig);
                requestParameters.Data = request.Data;
                HandlePathArguments(arguments, requestParameters);

                IResponse response = await CallApiAsync(ApiPathResolver.ResolvePath(arguments), requestParameters, ApiConfig);
                if (!IsSuccessCode(response))
                {
                    throw new ApiException(JsonConvert.DeserializeObject<ApiErrorResponse>(response.RawContent));
                }
                result.Response = response;
            }
            catch (Exception ex)
            {
                Error($"Exception executino operation {arguments.OperationName}: {ex.Message}", ex);
                result = new OperationResult(arguments, ex);
            }

            return result;
        }

        public Task<IOperationResult<T>> ExecuteAsync<T>(IOperationArguments<T> arguments)
        {
            throw new NotImplementedException();
        }
    }
}
