using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ICreateResult : IResult
    {
        ICreateArguments Arguments { get; }
        object CreatedObject { get; }
        Task SaveAsync();
    }
}
