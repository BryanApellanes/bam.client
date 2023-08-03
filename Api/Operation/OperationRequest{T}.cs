using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client.Operation
{
    public class OperationRequest<T> : OperationRequest, IOperationRequest<T>
    {
        public OperationRequest(IOperationArguments operationArguments, object data = null) : base(operationArguments, data)
        {
        }

        public List<T> ListData
        {
            get;
            set;
        }

        T IOperationRequest<T>.Data
        {
            get
            {
                return (T)Data;
            }
            set
            {
                Data = value;
            }
        }
    }
}
