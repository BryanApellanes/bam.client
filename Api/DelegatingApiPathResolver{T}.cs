using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class DelegatingApiPathResolver<T> : DelegatingApiPathResolver, IApiPathResolver<T>
    {
        public DelegatingApiPathResolver(Func<Type, IArguments, string> apiPathResolver) : base(apiPathResolver)
        {
        }
    }
}
