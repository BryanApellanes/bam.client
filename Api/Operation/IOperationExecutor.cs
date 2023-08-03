using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IOperationExecutor : IApiCaller
    {
        Task<IOperationRequest> CreateRequestAsync(IOperationArguments arguments);

        Task<IOperationResult> ExecuteAsync(IOperationArguments arguments);

        Task<IOperationRequest<T>> CreateRequestAsync<T>(IOperationArguments<T> arguments);

        Task<IOperationResult<T>> ExecuteAsync<T>(IOperationArguments<T> arguments);

    }
}
