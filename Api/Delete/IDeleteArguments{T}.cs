using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IDeleteArguments<T> : IDeleteArguments, IArguments<T>
    {
        new T Value { get; set; }
    }
}
