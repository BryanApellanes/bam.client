using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IRetrieveRequest<T> : IRetrieveRequest
    {
        new T Data { get; set; }
    }
}
