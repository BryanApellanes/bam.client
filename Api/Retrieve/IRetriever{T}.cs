using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IRetriever<T> : IRetriever
    {
        new Task<IRetrieveRequest<T>> CreateRequestAsync(IRetrieveArguments args);

        new Task<IRetrieveResult<T>> RetrieveAsync(IRetrieveArguments args);
    }
}
