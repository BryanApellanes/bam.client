using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client.Operation
{
    public class OperationArgument<T> : OperationArgument
    {
        public static implicit operator T(OperationArgument<T> argument)
        {
            return argument.ParameterValue;
        }

        public OperationArgument(string name, T value) : base(name, value)
        {
            this.ParameterValue = value;
        }

        public new T ParameterValue { get; set; }
    }
}
