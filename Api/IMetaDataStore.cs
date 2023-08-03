using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IMetaDataStore
    {
        IMetaDataStore SetMetaData<T>();
        IMetaDataStore SetMetaData<T>(IMetaData<T> metaData);

        IMetaData<T> GetMetaData<T>();
    }
}
