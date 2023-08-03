using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client.Operation
{
    public class OperationArguments<T> : OperationArguments, IOperationArguments<T>
    {
        public OperationArguments(string name) : base(name)
        {
        }

        public T Value
        {
            get;
            set;
        }
    }
}
