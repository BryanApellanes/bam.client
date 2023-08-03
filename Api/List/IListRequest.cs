using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IListRequest
    {
        IListArguments Arguments { get; }

        object Data { get; set; }

    }
}
