using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IListRequest<T> : IListRequest
    {
        new T Data { get; set; }
    }
}
