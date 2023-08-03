using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ISearchDataProvider<T>
    {
        Task<T> GetDataAsync(ISearchArguments arguments);
    }
}
