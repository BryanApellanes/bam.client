using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class RetrieveResult<T> : Result, IRetrieveResult<T>
    {
        public RetrieveResult(IRetrieveArguments arguments)
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }
        public RetrieveResult(IRetrieveArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        public new IRetrieveArguments Arguments
        {
            get;
            set;
        }

        public T RetrievedObject
        {
            get;
            set;
        }

        object IRetrieveResult.RetrievedObject
        {
            get => RetrievedObject;
        }

        public Task SaveAsync()
        {
            return Task.Run(() => SavePending());
        }
    }
}
