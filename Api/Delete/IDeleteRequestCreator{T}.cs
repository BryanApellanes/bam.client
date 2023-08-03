using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDeleteRequestCreator<T>
    {
        Task<IDeleteRequest<T>> CreateRequestAsync(IDeleteArguments advisoryArguments);

        Task<T> GetDefinitionAsync(IDeleteArguments advisoryArguments);
    }
}
