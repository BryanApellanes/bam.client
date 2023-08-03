using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IRetrieveResult : IResult
    {
        IRetrieveArguments Arguments { get; }
        object RetrievedObject { get; }
        Task SaveAsync();
    }
}
