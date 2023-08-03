using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class DataManager : IDataManager
    {
        StandardKernel kernel;
        public DataManager(IDataManagementContext dataManagementContext, StandardKernel diKernel = null) 
        {
            this.kernel = diKernel ?? Di.Kernel;
            this.DataManagementContext = dataManagementContext;
        }

        public ApiConfig ApiConfig 
        {
            get
            {
                return this.DataManagementContext?.ApiConfig;
            }
        }

        public IDataManagementContext DataManagementContext
        {
            get;
        }

        public async Task<ICreateResult<T>> CreateAsync<T>(ICreateArguments<T> createArguments)
        {
            return await kernel.Get<ICreator<T>>().CreateAsync(createArguments);
        }

        public async Task<IDeleteResult<T>> DeleteAsync<T>(IDeleteArguments<T> deleteArguments)
        {
            throw new NotImplementedException();
        }

        public async Task<IOperationResult> ExecuteAsync(IOperationArguments operationAguments)
        {
            throw new NotImplementedException();
        }

        public async Task<IOperationResult<T>> ExecuteAsync<T>(IOperationArguments<T> operationAguments)
        {
            throw new NotImplementedException();
        }

        public Task AddProcedureAsync(string procedureName, Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> procedure)
        {
            return DataManagementContext.AddProcedureAsync(procedureName, procedure);
        }

        public Task<IDataManagementProcedureResult> ExecuteProcedureAsync(string procedureName)
        {
            throw new NotImplementedException(); //return ExecuteProcedureAsync(new DataManagementProcedureArguments(this, procedureName));
        }

        public Task<IDataManagementProcedureResult> ExecuteProcedureAsync(IDataManagementProcedureArguments arguments)
        {
            return DataManagementContext.ExecuteProcedureAsync(arguments);
        }

        public Task<IListResult<T>> ListAsync<T>(IListArguments<T> listArguments)
        {
            throw new NotImplementedException();
        }

        public async Task<IRetrieveResult<T>> RetrieveAsync<T>(IRetrieveArguments<T> retrieveArguments)
        {
            throw new NotImplementedException();
        }

        public Task<ISearchResult<T>> SearchAsync<T>(ISearchArguments<T> searchArguments)
        {
            throw new NotImplementedException();
        }

        public Task<IUpdateResult<T>> UpdateAsync<T>(IUpdateArguments<T> updateArguments)
        {
            throw new NotImplementedException();
        }
    }
}
