using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class DeleteRequest<T> : IDeleteRequest<T>
    {
        public DeleteRequest(IDeleteArguments arguments, T toDelete)
        {
            this.Arguments = arguments;
            this.Data = toDelete;
        }

        public T Data
        {
            get;
            set;
        }
        public IDeleteArguments Arguments
        {
            get;
            set;
        }

        object IDeleteRequest.Data
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
