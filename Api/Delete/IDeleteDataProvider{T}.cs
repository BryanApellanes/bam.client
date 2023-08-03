using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDeleteDataProvider<T>
    {
        Task<T> GetDataAsync(IDeleteArguments arguments);
    }
}
