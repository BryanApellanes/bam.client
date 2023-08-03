using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ISearchArguments<T> : ISearchArguments, IArguments<T>
    {
        new T Value { get; set; }
    }
}
