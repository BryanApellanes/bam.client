using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ICreateRequest
    {
        ICreateArguments Arguments { get; }

        object Data { get; set; }

    }
}
