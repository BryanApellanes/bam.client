using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IOperationArguments<T> : IOperationArguments, IArguments<T>
    {
        T Value { get; }
    }
}
