using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ListRequest<T> : IListRequest<T>
    {
        public ListRequest(IListArguments arguments, T toList)
        {
            this.Arguments = arguments;
            this.Data = toList;
        }

        public T Data
        {
            get;
            set;
        }

        public IListArguments Arguments
        {
            get;
            set;
        }

        object IListRequest.Data
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
