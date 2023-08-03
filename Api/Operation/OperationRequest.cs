using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client.Operation
{
    public class OperationRequest : IOperationRequest
    {
        public OperationRequest(IOperationArguments operationArguments, object data = null)
        {
            this.Arguments = operationArguments;
            this.Data = data;
        }
        public string OperationName
        {
            get
            {
                return Arguments?.OperationName;
            }
        }

        public IOperationArguments Arguments
        {
            get;
            set;
        }

        public object Data
        {
            get;
            set;
        }

    }
}
