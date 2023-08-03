using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IApiCaller
    {
        IApiPathResolver ApiPathResolver { get; }
        ApiClient ApiClient { get; }
    }
}
