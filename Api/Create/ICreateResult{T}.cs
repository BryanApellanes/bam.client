using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ICreateResult<T> : ICreateResult
    {
        new T CreatedObject { get; set; }
    }
}
