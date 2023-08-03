using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDeleteResult : IResult
    {
        IDeleteArguments Arguments { get; }
        object DeletedObject { get; }
        Task SaveAsync();
    }
}
