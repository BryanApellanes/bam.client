using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using YamlDotNet.Serialization;

namespace Bam.Client.Operation
{
    public interface IOperationRequestCreator
    {
        Task<IOperationRequest> CreateRequestAsync(IOperationArguments arguments);

        //Task<object> GetDefinitionAsync(IOperationArguments arguments);

        Task<IOperationRequest<T>> CreateRequestAsync<T>(IOperationArguments<T> arguments);

        //Task<T> GetDefinitionAsync<T>(IOperationArguments<T> arguments);
    }
}
