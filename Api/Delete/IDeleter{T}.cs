using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDeleter<T> : IDeleter
    {
        new Task<IDeleteRequest<T>> CreateRequestAsync(IDeleteArguments args);

        new Task<IDeleteResult<T>> DeleteAsync(IDeleteArguments args);
    }
}
