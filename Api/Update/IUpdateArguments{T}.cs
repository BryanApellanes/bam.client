using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IUpdateArguments<T> : IUpdateArguments, IArguments<T>
    {
        new T Value { get; set; }
    }
}
