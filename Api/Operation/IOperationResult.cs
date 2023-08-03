using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IOperationResult: IResult
    {
        IOperationArguments Arguments { get; }
        object Data { get; }
        Task SaveAsync();
    }
}
