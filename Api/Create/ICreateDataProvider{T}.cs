using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ICreateDataProvider<T>
    {
        Task<T> GetDataDefinitionAsync(ICreateArguments arguments);
    }
}
