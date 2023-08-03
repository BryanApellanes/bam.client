using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IOperationExecutor<T> : IOperationExecutor
    {
        new Task<IOperationRequest<T>> CreateRequestAsync(IOperationArguments arguments);

        new Task<IOperationResult<T>> ExecuteAsync(IOperationArguments arguments);
    }
}
