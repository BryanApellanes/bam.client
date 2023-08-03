using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IDeleteResult<T> : IDeleteResult
    {
        new T DeletedObject { get; set; }
    }
}
