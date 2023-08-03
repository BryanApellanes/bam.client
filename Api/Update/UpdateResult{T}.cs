using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class UpdateResult<T> : Result, IUpdateResult<T>
    {
        public UpdateResult(IUpdateArguments arguments)
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }
        public UpdateResult(IUpdateArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        public new IUpdateArguments Arguments
        {
            get;
            set;
        }

        public T UpdatedObject
        {
            get;
            set;
        }

        object IUpdateResult.UpdatedObject
        {
            get => UpdatedObject;
        }

        public Task SaveAsync()
        {
            return Task.Run(() => SavePending());
        }
    }
}
