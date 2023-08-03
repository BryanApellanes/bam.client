using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class MessageResult : Result
    {
        public MessageResult(string message, bool succeeded = false)
        {            
            this.Message = message;
            this.OperationSucceeded = succeeded;
            if(!succeeded)
            {
                this.Exception = new Exception(message);
            }
        }
    }
}
