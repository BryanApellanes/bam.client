using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IRetriever : IApiCaller
    {
        Task<IRetrieveRequest> CreateRequestAsync(IRetrieveArguments args);

        Task<IRetrieveResult> RetrieveAsync(IRetrieveArguments args);
    }
}
