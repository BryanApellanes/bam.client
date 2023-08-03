using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IListDataProvider<T>
    {
        Task<T> GetDataAsync(IListArguments arguments);
    }
}
