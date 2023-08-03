using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client.Operation
{
    public interface IOperationDataProvider
    {
        Task<OperationArgument[]> GetDataAsync(IOperationArguments arguments);
    }
}
