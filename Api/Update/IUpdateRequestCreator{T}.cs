using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IUpdateRequestCreator<T>
    {
        Task<IUpdateRequest<T>> CreateRequestAsync(IUpdateArguments advisoryArguments);

        Task<T> GetDefinitionAsync(IUpdateArguments advisoryArguments);
    }
}
