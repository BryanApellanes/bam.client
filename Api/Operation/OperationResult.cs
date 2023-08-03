using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client.Operation
{
    public class OperationResult : Result, IOperationResult
    {
        public OperationResult(IOperationArguments arguments) 
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }

        public OperationResult(IOperationArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        public new IOperationArguments Arguments 
        {
            get; 
            set; 
        }

        public object Data
        {
            get;
            set;
        }

        public Task SaveAsync()
        {
            return Task.Run(() => SavePending());
        }
    }
}
