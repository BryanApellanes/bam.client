using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IResponse<T> : IResponse
    {
        /// <summary>
        /// The content of this response
        /// </summary>
        T Data { get; }
    }
}
