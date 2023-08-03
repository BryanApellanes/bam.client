using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class UpdateRequestCreator<T> : IUpdateRequestCreator<T>
    {
        public UpdateRequestCreator(IUpdateDataProvider<T> objectDefinitionProvider)
        {
            ObjectDefinitionProvider = objectDefinitionProvider;
        }

        protected IUpdateDataProvider<T> ObjectDefinitionProvider
        {
            get;
            private set;
        }

        public async Task<IUpdateRequest<T>> CreateRequestAsync(IUpdateArguments arguments)
        {
            return new UpdateRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<T> GetDefinitionAsync(IUpdateArguments arguments)
        {
            return await ObjectDefinitionProvider.GetDataAsync(arguments);
        }
    }
}
