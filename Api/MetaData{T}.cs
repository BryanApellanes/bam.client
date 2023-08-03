using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class MetaData<T> : IMetaData<T>
    {
        public const string PathFormat = "/api/v1/{0}";

        public MetaData(T data, Func<Type, IArguments, string> apiPathResolver = null)
        {
            this._for = data;
            this.ApiPathResolver = new DelegatingApiPathResolver<T>(apiPathResolver ?? DefaultPathResolver);
        }

        protected static Func<Type, IArguments, string> DefaultPathResolver
        {
            get
            {
                return (type, args) => string.Format(PathFormat, type.Name.ToLowerInvariant());
            }
        }

        protected IApiPathResolver<T> ApiPathResolver
        {
            get; set;
        }

        T _for;
        public T For
        {
            get
            {
                return _for;
            }
        }

        public Type Type
        {
            get
            {
                return typeof(T);
            }
        }

        public string GetPath(IArguments arguments)
        {
            return ApiPathResolver.ResolvePath(Type, arguments);
        }

        object IMetaData.For
        {
            get
            {
                return this._for;
            }
        }
    }
}
