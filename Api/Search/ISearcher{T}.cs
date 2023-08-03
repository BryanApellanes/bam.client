using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ISearcher<T> : ISearcher
    {
        new Task<ISearchRequest<T>> CreateRequestAsync(ISearchArguments args);

        new Task<ISearchResult<T>> SearchAsync(ISearchArguments args);
    }
}
