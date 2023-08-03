using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IOperationRequest
    {
        string OperationName { get; }
        IOperationArguments Arguments { get; }

        object Data { get; }
    }
}
