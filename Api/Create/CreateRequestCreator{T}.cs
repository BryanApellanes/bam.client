// <copyright file="CreateRequestCreator{T}.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace Bam.Client
{
    /// <summary>
    /// Component used to create CreateRequests.
    /// </summary>
    /// <typeparam name="T">The type of data that is created.</typeparam>
    public class CreateRequestCreator<T> : ICreateRequestCreator<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequestCreator{T}"/> class.
        /// </summary>
        /// <param name="objectDefinitionProvider"></param>
        public CreateRequestCreator(ICreateDataProvider<T> objectDefinitionProvider)
        {
            this.CreateArgumentsProvider = objectDefinitionProvider;
        }

        protected ICreateDataProvider<T> CreateArgumentsProvider
        {
            get;
            private set;
        }

        /// <summary>
        /// Creates a request using the specified arguments.
        /// </summary>
        /// <param name="arguments"></param>
        /// <returns></returns>
        public async Task<ICreateRequest<T>> CreateRequestAsync(ICreateArguments arguments)
        {
            return new CreateRequest<T>(arguments, await GetDefinitionAsync(arguments));
        }

        public async Task<T> GetDefinitionAsync(ICreateArguments arguments)
        {
            return await CreateArgumentsProvider.GetDataDefinitionAsync(arguments);
        }
    }
}
