using Bam.Client.Operation;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class DataProvider<T> : ICreateDataProvider<T>, IRetrieveDataProvider<T>, IUpdateDataProvider<T>, IDeleteDataProvider<T>, IListDataProvider<T>, ISearchDataProvider<T>, IOperationDataProvider
    {
        public DataProvider() : this((args) => default(T))
        {
        }

        public DataProvider(Func<IArguments, T> implementation) 
        {
            GetData = implementation;
            GetCreateData = implementation;
            GetRetrieveData = implementation;
            GetUpdateData = implementation;
            GetDeleteData = implementation;
            GetListData = implementation;
            GetSearchData = implementation;            
        }

        public Func<IArguments, T> GetData { get; set; }

        public Func<ICreateArguments, T> GetCreateData { get; set; }

        public Func<IRetrieveArguments, T> GetRetrieveData { get; set; }

        public Func<IUpdateArguments, T> GetUpdateData { get; set; }
        public Func<IDeleteArguments, T> GetDeleteData { get; set; }
        public Func<IListArguments, T> GetListData { get; set; }
        public Func<ISearchArguments, T> GetSearchData { get; set; }

        public Func<IOperationArguments, OperationArgument[]> GetOperationData { get; set; }

        public async Task<T> GetDataDefinitionAsync(ICreateArguments arguments)
        {
            return GetCreateData(arguments);
        }

        public async Task<T> GetDataAsync(IRetrieveArguments arguments)
        {
            return GetRetrieveData(arguments);
        }

        public async Task<T> GetDataAsync(IUpdateArguments arguments)
        {
            return GetUpdateData(arguments);
        }

        public async Task<T> GetDataAsync(IDeleteArguments arguments)
        {
            return GetDeleteData(arguments);
        }

        public async Task<T> GetDataAsync(IListArguments arguments)
        {
            return GetListData(arguments);
        }

        public async Task<T> GetDataAsync(ISearchArguments arguments)
        {
            return GetSearchData(arguments);
        }

        public async Task<OperationArgument[]> GetDataAsync(IOperationArguments arguments)
        {
            return GetOperationData(arguments);
        }
    }
}
