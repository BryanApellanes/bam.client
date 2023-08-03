using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class DataManagementProcedure : IDataManagementProcedure
    {
        public DataManagementProcedure(IDataManagementContext dataManager, string procedureName, Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> executeImplementation)
        {
            DataManagementContext = dataManager;
            ProcedureName = procedureName;
            ExecuteImplementation = executeImplementation;
        }

        public string ProcedureName
        {
            get;
            private set;
        }

        public IDataManagementContext DataManagementContext
        {
            get;
            private set;
        }

        public async Task<IDataManagementProcedureResult> ExecuteAsync(IDataManagementProcedureArguments arguments)
        {
            return await ExecuteImplementation(arguments).ConfigureAwait(false);
        }

        public async Task<IDataManagementProcedureResult<T>> ExecuteAsync<T>(IDataManagementProcedureArguments arguments)
        {
            IDataManagementProcedureResult result = await ExecuteImplementation(arguments).ConfigureAwait(false);
            return result as IDataManagementProcedureResult<T>;
        }

        public Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> ExecuteImplementation
        {
            get;
            private set;
        }
    }
}
