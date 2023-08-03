using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface ISearchResult : IResult
    {
        ISearchArguments Arguments { get; }
        object SearchdObject { get; }
        Task SaveAsync();
    }
}
