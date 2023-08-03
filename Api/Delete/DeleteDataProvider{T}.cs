using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public abstract class DeleteDataProvider<T> : LogEventWriter, IDeleteDataProvider<T>
    {
        public abstract Task<T> GetDataAsync(IDeleteArguments arguments);
    }
}
