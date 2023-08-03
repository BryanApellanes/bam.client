using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client.Operation
{
    public class OperationArgument
    {
        public OperationArgument(string name, object value)
        {
            ParameterName = name;
            Value = value;
        }
  
        public string ParameterName { get; set; }
        public object Value { get; set; }
    }
}
