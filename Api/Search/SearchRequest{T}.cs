using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class SearchRequest<T> : ISearchRequest<T>
    {
        public SearchRequest(ISearchArguments arguments, T toSearch)
        {
            this.Arguments = arguments;
            this.Data = toSearch;
        }

        public T Data
        {
            get;
            set;
        }
        public ISearchArguments Arguments
        {
            get;
            set;
        }

        object ISearchRequest.Data
        {
            get
            {
                return Data;
            }
            set
            {
                Data = (T)value;
            }
        }
    }
}
