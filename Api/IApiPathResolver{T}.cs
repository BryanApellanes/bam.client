using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IApiPathResolver<T> : IApiPathResolver
    {
        new string ResolvePath(IArguments arguments);
    }
}
