using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IRetrieveDataProvider<T>
    {
        Task<T> GetDataAsync(IRetrieveArguments arguments);
    }
}
