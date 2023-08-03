using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IRetrieveArguments<T> : IRetrieveArguments, IArguments<T>
    {
        new T Value { get; set; }
    }
}
