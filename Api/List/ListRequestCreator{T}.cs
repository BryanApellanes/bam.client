using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class ListRequestCreator<T> : IListRequestCreator<T>
    {
        public ListRequestCreator(IListDataProvider<T> objectDefinitionProvider)
        {
            ObjectDefinitionProvider = objectDefinitionProvider;
        }

        protected IListDataProvider<T> ObjectDefinitionProvider
        {
            get;
            private set;
        }

        public async Task<IListRequest<T>> CreateRequestAsync(IListArguments arguments)
        {
            return new ListRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<T> GetDefinitionAsync(IListArguments arguments)
        {
            return await ObjectDefinitionProvider.GetDataAsync(arguments);
        }
    }
}
