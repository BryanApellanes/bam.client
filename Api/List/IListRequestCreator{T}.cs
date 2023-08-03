using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IListRequestCreator<T>
    {
        Task<IListRequest<T>> CreateRequestAsync(IListArguments advisoryArguments);

        Task<T> GetDefinitionAsync(IListArguments advisoryArguments);
    }
}
