using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ICreator : IApiCaller
    {
        Task<ICreateRequest> CreateRequestAsync(ICreateArguments args);

        Task<ICreateResult> CreateAsync(ICreateArguments args);
    }
}
