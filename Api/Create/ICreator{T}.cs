using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ICreator<T> : IApiCaller
    {
        Task<ICreateRequest<T>> CreateRequestAsync(ICreateArguments<T> args);

        Task<ICreateResult<T>> CreateAsync(ICreateArguments<T> args);
    }
}
