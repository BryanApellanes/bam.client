using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IMetaData<T> : IMetaData
    {
        new T For { get; }
    }
}
