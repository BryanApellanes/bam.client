using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class DelegatingApiPathResolver : IApiPathResolver
    {
        public DelegatingApiPathResolver(Func<Type, IArguments, string> apiPathResolver) 
        {
            this.TypedApiPathResolver = apiPathResolver;
        }
        public DelegatingApiPathResolver(Func<IArguments, string> apiPathResolver)
        {
            this.ApiPathResolver = apiPathResolver;
        }

        protected Func<Type, IArguments, string> TypedApiPathResolver
        {
            get;
            set;
        }

        protected Func<IArguments, string> ApiPathResolver
        {
            get;
            set;
        }

        public string ResolvePath(Type objectType, IArguments arguments)
        {
            return TypedApiPathResolver(objectType, arguments);
        }

        public string ResolvePath<T>(IArguments arguments)
        {
            return TypedApiPathResolver(typeof(T), arguments);
        }

        public string ResolvePath(IArguments arguments)
        {
            return ApiPathResolver(arguments);
        }
    }
}
