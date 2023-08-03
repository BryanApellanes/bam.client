using System;

namespace Bam.Client
{
    public interface IMetaData
    {
        object For { get; }
        Type Type { get; }
        string GetPath(IArguments arguments);
    }
}