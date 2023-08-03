using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IUpdateDataProvider<T>
    {
        Task<T> GetDataAsync(IUpdateArguments arguments);
    }
}
