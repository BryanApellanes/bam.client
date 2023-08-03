using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class RetrieveRequest<T> : IRetrieveRequest<T>
    {
        public RetrieveRequest(IRetrieveArguments arguments, T toRetrieve)
        {
            this.Arguments = arguments;
            this.Data = toRetrieve;
        }

        public T Data
        {
            get;
            set;
        }
        public IRetrieveArguments Arguments
        {
            get;
            set;
        }

        object IRetrieveRequest.Data
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
