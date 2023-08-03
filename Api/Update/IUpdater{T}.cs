using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IUpdater<T> : IUpdater
    {
        new Task<IUpdateRequest<T>> CreateRequestAsync(IUpdateArguments args);

        new Task<IUpdateResult<T>> UpdateAsync(IUpdateArguments args);
    }
}
