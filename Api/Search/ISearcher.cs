using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ISearcher : IApiCaller
    {
        Task<ISearchRequest> CreateRequestAsync(ISearchArguments args);

        Task<ISearchResult> SearchAsync(ISearchArguments args);
    }
}
