using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public abstract class SearchDataProvider<T> : LogEventWriter, ISearchDataProvider<T>
    {
        public abstract Task<T> GetDataAsync(ISearchArguments arguments);
    }
}
