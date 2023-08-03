using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IUpdateResult : IResult
    {
        IUpdateArguments Arguments { get; }
        object UpdatedObject { get; }
        Task SaveAsync();
    }
}
