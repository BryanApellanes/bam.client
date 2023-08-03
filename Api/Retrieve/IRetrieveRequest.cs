using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IRetrieveRequest
    {
        IRetrieveArguments Arguments { get; }

        object Data { get; set; }

    }
}
