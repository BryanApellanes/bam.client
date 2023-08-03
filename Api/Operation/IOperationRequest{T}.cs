using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IOperationRequest<T>: IOperationRequest
    {
        new T Data { get; set; }
        List<T> ListData { get; set; }
    }
}
