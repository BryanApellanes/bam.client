// <copyright file="IDataManagementContext.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Threading.Tasks;

namespace Bam.Client
{
    /// <summary>
    /// Context for managment of data.
    /// </summary>
    public interface IDataManagementContext
    {
        /// <summary>
        /// Gets the ApiConfig.
        /// </summary>
        ApiConfig ApiConfig { get; }

        /// <summary>
        /// Gets the ApiPathResolver.
        /// </summary>
        IApiPathResolver ApiPathResolver { get; }

        /// <summary>
        /// Get an instance of the specified generic type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <returns>instance of T.</returns>
        T GetService<T>();

        /// <summary>
        /// Set the instance of the specified generic type.
        /// </summary>
        /// <typeparam name="T">The type.</typeparam>
        /// <param name="service">instance of T.</param>
        void SetService<T>(T service);

        /// <summary>
        /// Add a procedure.
        /// </summary>
        /// <param name="procedureName">The name of the procedure.</param>
        /// <param name="procedure">The procedure.</param>
        /// <returns>Task.</returns>
        Task AddProcedureAsync(string procedureName, Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> procedure);

        /// <summary>
        /// Execute a procedure.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Task{IDataManagementProcedureResult}</returns>
        Task<IDataManagementProcedureResult> ExecuteProcedureAsync(IDataManagementProcedureArguments arguments);
    }
}
