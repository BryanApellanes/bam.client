using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class RetrieveRequestCreator<T> : IRetrieveRequestCreator<T>
    {
        public RetrieveRequestCreator(IRetrieveDataProvider<T> objectDefinitionProvider)
        {
            ObjectDefinitionProvider = objectDefinitionProvider;
        }

        protected IRetrieveDataProvider<T> ObjectDefinitionProvider
        {
            get;
            private set;
        }
        public async Task<IRetrieveRequest<T>> GetRequestAsync(IRetrieveArguments arguments)
        {
            return new RetrieveRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<T> GetDefinitionAsync(IRetrieveArguments arguments)
        {
            return await ObjectDefinitionProvider.GetDataAsync(arguments);
        }
    }
}
