using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public abstract class ListDataProvider<T> : LogEventWriter, IListDataProvider<T>
    {
        public abstract Task<T> GetDataAsync(IListArguments arguments);
    }
}
