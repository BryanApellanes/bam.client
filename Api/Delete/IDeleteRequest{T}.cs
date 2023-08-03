using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IDeleteRequest<T> : IDeleteRequest
    {
        new T Data { get; set; }
    }
}
