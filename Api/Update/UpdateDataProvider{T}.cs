using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public abstract class UpdateDataProvider<T> : LogEventWriter, IUpdateDataProvider<T>
    {
        public abstract Task<T> GetDataAsync(IUpdateArguments arguments);
    }
}
