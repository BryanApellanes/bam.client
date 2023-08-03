using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IUpdateRequest
    {
        IUpdateArguments Arguments { get; }

        object ObjectToUpdate { get; set; }

    }
}
