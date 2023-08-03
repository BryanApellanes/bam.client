using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ILister<T> : ILister
    {
        new Task<IListRequest<T>> CreateRequestAsync(IListArguments args);

        new Task<IListResult<T>> ListAsync(IListArguments args);
    }
}
