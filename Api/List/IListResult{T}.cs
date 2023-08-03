using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IListResult<T> : IListResult
    {
        new T[] List { get; set; }
    }
}
