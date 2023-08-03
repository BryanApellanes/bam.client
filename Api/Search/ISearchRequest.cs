using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface ISearchRequest
    {
        ISearchArguments Arguments { get; }

        object Data { get; set; }

    }
}
