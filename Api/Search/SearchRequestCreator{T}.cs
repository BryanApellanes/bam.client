using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class SearchRequestCreator<T> : ISearchRequestCreator<T>
    {
        public SearchRequestCreator(ISearchDataProvider<T> objectDefinitionProvider)
        {
            ObjectDefinitionProvider = objectDefinitionProvider;
        }

        protected ISearchDataProvider<T> ObjectDefinitionProvider
        {
            get;
            private set;
        }
        public async Task<ISearchRequest<T>> CreateRequestAsync(ISearchArguments arguments)
        {
            return new SearchRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<T> GetDefinitionAsync(ISearchArguments arguments)
        {
            return await ObjectDefinitionProvider.GetDataAsync(arguments);
        }
    }
}
