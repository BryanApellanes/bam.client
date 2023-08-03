using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client.Operation
{
    public interface IOperationRequestCreator<T> : IOperationRequestCreator
    {
        Task<IOperationRequest<T>> GetRequestAsync(IOperationArguments<T> arguments);

        Task<T> GetDefinitionAsync(IOperationArguments<T> arguments);
    }
}
