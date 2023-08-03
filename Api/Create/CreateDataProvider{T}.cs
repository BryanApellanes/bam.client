// <copyright file="CreateDataProvider{T}.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Threading.Tasks;

namespace Bam.Client
{
    /// <summary>
    /// Provides data to a <see cref="ICreateRequest" />
    /// </summary>
    /// <typeparam name="T">The type of data to create.</typeparam>
    public abstract class CreateDataProvider<T> : LogEventWriter, ICreateDataProvider<T>
    {
        /// <summary>
        /// Gets the data to create.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Task{T}</returns>
        public abstract Task<T> GetDataDefinitionAsync(ICreateArguments arguments);
    }
}
