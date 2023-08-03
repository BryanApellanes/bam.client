using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IDeleteRequest
    {
        IDeleteArguments Arguments { get; }

        object Data { get; set; }

    }
}
