using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class DeleteResult<T> : Result, IDeleteResult<T>
    {
        public DeleteResult(IDeleteArguments arguments)
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }
        public DeleteResult(IDeleteArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        public new IDeleteArguments Arguments
        {
            get;
            set;
        }

        public T DeletedObject
        {
            get;
            set;
        }

        object IDeleteResult.DeletedObject
        {
            get => DeletedObject;
        }

        public Task SaveAsync()
        {
            return Task.Run(() => SavePending());
        }
    }
}
