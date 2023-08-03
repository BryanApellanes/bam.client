using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public abstract class Result : Jsonable, IResult
    {
        public virtual bool OperationSucceeded
        {
            get;
            set;
        }
        public string Message
        {
            get;
            set;
        }

        public virtual Exception Exception
        {
            get;
            set;
        }

        public IArguments Arguments
        {
            get;
            set;
        }

        public IResponse Response
        {
            get;
            set;
        }
    }
}
