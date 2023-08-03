using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;

namespace Bam.Client.Operation
{
    public class OperationArguments : Arguments, IOperationArguments
    {
        public OperationArguments(string name) : base()
        {
            this.OperationName = name;
        }

        public string OperationName
        {
            get; 
            set;
        }

        public HttpMethod HttpMethod
        { 
            get; 
            set; 
        }
    }
}
