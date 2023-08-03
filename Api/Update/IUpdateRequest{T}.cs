using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IUpdateRequest<T> : IUpdateRequest
    {
        new T ObjectToUpdate { get; set; }
    }
}
