using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDataManagementProcedure
    {
        IDataManagementContext DataManagementContext { get; }

        string ProcedureName { get; }

        Task<IDataManagementProcedureResult> ExecuteAsync(IDataManagementProcedureArguments arguments);
        Task<IDataManagementProcedureResult<T>> ExecuteAsync<T>(IDataManagementProcedureArguments arguments);

        Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> ExecuteImplementation { get; }
    }
}
