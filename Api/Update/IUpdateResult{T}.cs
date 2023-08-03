using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IUpdateResult<T> : IUpdateResult
    {
        new T UpdatedObject { get; set; }
    }
}
