using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public abstract class RetrieveDataProvider<T> : LogEventWriter, IRetrieveDataProvider<T>
    {
        public abstract Task<T> GetDataAsync(IRetrieveArguments arguments);
    }
}
