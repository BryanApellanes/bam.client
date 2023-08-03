using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ISearchRequest<T> : ISearchRequest
    {
        new T Data { get; set; }
    }
}
