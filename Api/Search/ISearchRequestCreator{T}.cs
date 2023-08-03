using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ISearchRequestCreator<T>
    {
        Task<ISearchRequest<T>> CreateRequestAsync(ISearchArguments advisoryArguments);

        Task<T> GetDefinitionAsync(ISearchArguments advisoryArguments);
    }
}
