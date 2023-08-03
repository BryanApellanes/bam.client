using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class UpdateRequest<T> : IUpdateRequest<T>
    {
        public UpdateRequest(IUpdateArguments arguments, T toUpdate)
        {
            this.Arguments = arguments;
            this.ObjectToUpdate = toUpdate;
        }

        public T ObjectToUpdate
        {
            get;
            set;
        }
        public IUpdateArguments Arguments
        {
            get;
            set;
        }

        object IUpdateRequest.ObjectToUpdate
        {
            get
            {
                return ObjectToUpdate;
            }
            set
            {
                ObjectToUpdate = (T)value;
            }
        }
    }
}
