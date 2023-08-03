using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IUpdater : IApiCaller
    {
        Task<IUpdateRequest> CreateRequestAsync(IUpdateArguments args);

        Task<IUpdateResult> UpdateAsync(IUpdateArguments args);
    }
}
