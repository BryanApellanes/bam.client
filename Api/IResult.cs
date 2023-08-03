using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace Bam.Client
{
    public interface IResult : IJsonable
    {
        bool OperationSucceeded { get; }

        string Message { get; }

        [JsonIgnore]
        Exception Exception { get; }

        IArguments Arguments { get; }

        IResponse Response { get; }
    }
}
