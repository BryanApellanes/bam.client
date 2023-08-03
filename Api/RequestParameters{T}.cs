using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class RequestParameters<T> :RequestParameters
    {
        public new T Data { get; set; }
    }
}
