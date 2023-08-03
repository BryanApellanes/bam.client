using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client.Operation
{
    public class OperationRequestCreator : ApiCaller, IOperationRequestCreator
    {
        public OperationRequestCreator(ApiConfig sdkConfig, IDataManagementContext dataManagementContext, IOperationDataProvider operationArgumentsProvider): base(sdkConfig, dataManagementContext)
        { 
            OperationArgumentsProvider = operationArgumentsProvider;
        }

        protected IOperationDataProvider OperationArgumentsProvider
        {
            get;
            set;
        }

        public async Task<object> GetDefinitionAsync(IOperationArguments arguments)
        {
            return await OperationArgumentsProvider.GetDataAsync(arguments);
        }

        public async Task<IOperationRequest> CreateRequestAsync(IOperationArguments arguments)
        {
            return new OperationRequest(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<IOperationRequest<T>> CreateRequestAsync<T>(IOperationArguments<T> arguments)
        {
            return new OperationRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }
    }
}
