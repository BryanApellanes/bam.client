using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ICreateRequest<T> : ICreateRequest
    {
        new T Data { get; set; }
    }
}
