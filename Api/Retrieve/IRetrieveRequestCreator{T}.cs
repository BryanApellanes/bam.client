using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IRetrieveRequestCreator<T>
    {
        Task<IRetrieveRequest<T>> GetRequestAsync(IRetrieveArguments advisoryArguments);

        Task<T> GetDefinitionAsync(IRetrieveArguments advisoryArguments);
    }
}
