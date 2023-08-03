using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{

    public interface ICreateRequestCreator<T>
    {
        Task<ICreateRequest<T>> CreateRequestAsync(ICreateArguments advisoryArguments);

        Task<T> GetDefinitionAsync(ICreateArguments advisoryArguments);
    }
}
