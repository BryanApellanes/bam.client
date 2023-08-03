using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IListResult : IResult
    {
        IListArguments Arguments { get; }
        object[] List { get; }
        Task SaveAsync();
    }
}
