using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public interface IDataManager
    {
        ApiConfig ApiConfig { get; }
        IDataManagementContext DataManagementContext { get; }

        Task<ICreateResult<T>> CreateAsync<T>(ICreateArguments<T> createArguments);
        Task<IRetrieveResult<T>> RetrieveAsync<T>(IRetrieveArguments<T> retrieveArguments);
        Task<IUpdateResult<T>> UpdateAsync<T>(IUpdateArguments<T> updateArguments);
        Task<IDeleteResult<T>> DeleteAsync<T>(IDeleteArguments<T> deleteArguments);
        Task<IListResult<T>> ListAsync<T>(IListArguments<T> listArguments);
        Task<ISearchResult<T>> SearchAsync<T>(ISearchArguments<T> searchArguments);

        Task<IOperationResult> ExecuteAsync(IOperationArguments operationAguments);

        Task<IOperationResult<T>> ExecuteAsync<T>(IOperationArguments<T> operationAguments);

        Task AddProcedureAsync(string procedureName, Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> procedure);

        Task<IDataManagementProcedureResult> ExecuteProcedureAsync(IDataManagementProcedureArguments procedureArguments);
    }
}
