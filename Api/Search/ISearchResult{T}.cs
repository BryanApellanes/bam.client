using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ISearchResult<T> : ISearchResult
    {
        new T SearchdObject { get; set; }
    }
}
