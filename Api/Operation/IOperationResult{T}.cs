using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IOperationResult<T>: IOperationResult
    {
        new T Data { get; }
    }
}
