using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ILister : IApiCaller
    {
        Task<IListRequest> CreateRequestAsync(IListArguments args);

        Task<IListResult> ListAsync(IListArguments args);
    }
}
