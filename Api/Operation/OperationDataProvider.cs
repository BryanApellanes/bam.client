using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client.Operation
{
    public abstract class OperationDataProvider : LogEventWriter, IOperationDataProvider
    {
        public abstract Task<OperationArgument[]> GetDataAsync(IOperationArguments arguments);
    }
}
