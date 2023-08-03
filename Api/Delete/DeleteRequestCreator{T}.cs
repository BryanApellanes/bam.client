using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class DeleteRequestCreator<T> : IDeleteRequestCreator<T>
    {
        public DeleteRequestCreator(IDeleteDataProvider<T> objectDefinitionProvider)
        {
            ObjectDefinitionProvider = objectDefinitionProvider;
        }

        protected IDeleteDataProvider<T> ObjectDefinitionProvider
        {
            get;
            private set;
        }
        public async Task<IDeleteRequest<T>> CreateRequestAsync(IDeleteArguments arguments)
        {
            return new DeleteRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<T> GetDefinitionAsync(IDeleteArguments arguments)
        {
            return await ObjectDefinitionProvider.GetDataAsync(arguments);
        }
    }
}
