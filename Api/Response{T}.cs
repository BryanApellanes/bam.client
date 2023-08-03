using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Bam.Client
{
    public class Response<T> : Response, IResponse<T>
    {
        public Response(HttpStatusCode statusCode, string rawContent) : base(statusCode, rawContent)
        {
            this.ResponseType = typeof(T);
        }

        public override Type ResponseType
        {
            get;
            protected set;
        }

        public T Data { get; set; }
    }
}
