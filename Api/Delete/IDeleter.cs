using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDeleter : IApiCaller
    {
        Task<IDeleteRequest> CreateRequestAsync(IDeleteArguments args);

        Task<IDeleteResult> DeleteAsync(IDeleteArguments args);
    }
}
