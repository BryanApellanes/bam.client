// <copyright file="DataManagementContext.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ninject;

namespace Bam.Client
{
    /// <inheritdoc />
    public class DataManagementContext : IDataManagementContext
    {
        private readonly StandardKernel kernel;
        private readonly Dictionary<string, IDataManagementProcedure> procedures = new Dictionary<string, IDataManagementProcedure>();

        /// <summary>
        /// Initializes a new instance of the <see cref="DataManagementContext"/> class.
        /// </summary>
        /// <param name="apiConfig">The configuration.</param>
        /// <param name="apiPathResolver">The path resolver.</param>
        /// <param name="kernel">The dependency injection kernel.</param>
        public DataManagementContext(ApiConfig apiConfig, IApiPathResolver apiPathResolver, StandardKernel kernel = null)
        {
            this.kernel = kernel ?? new StandardKernel();
            this.ApiConfig = apiConfig;
            this.ApiPathResolver = apiPathResolver;
            this.kernel.Bind<ApiConfig>().ToConstant(apiConfig);
            this.kernel.Bind<IDataManagementContext>().ToConstant(this);
        }

        /// <inheritdoc />
        public ApiConfig ApiConfig { get; private set; }

        /// <inheritdoc />
        public IApiPathResolver ApiPathResolver
        {
            get;
            private set;
        }

        /// <inheritdoc />
        public T GetService<T>()
        {
            return this.kernel.Get<T>();
        }

        /// <inheritdoc />
        public void SetService<T>(T service)
        {
            this.kernel.Bind<T>().ToConstant(service);
        }

        /// <inheritdoc />
        public async Task AddProcedureAsync(string procedureName, Func<IDataManagementProcedureArguments, Task<IDataManagementProcedureResult>> procedure)
        {
            this.procedures.Add(procedureName, new DataManagementProcedure(this, procedureName, procedure));
        }

        /// <inheritdoc />
        public Task<IDataManagementProcedureResult> ExecuteProcedureAsync(IDataManagementProcedureArguments arguments)
        {
            return this.ExecuteProcedureAsync(arguments.ProcedureName, arguments);
        }

        /// <summary>
        /// Execute the procedure with the specified name.
        /// </summary>
        /// <param name="procedureName">The name of the procedure.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Task{IDataManagementProcedureResult}</returns>
        /// <exception cref="ArgumentNullException">Thrown if procedureName is not specified (null or empty).</exception>
        /// <exception cref="InvalidOperationException">Thrown if the specified procedure is not set.</exception>
        public Task<IDataManagementProcedureResult> ExecuteProcedureAsync(string procedureName, IDataManagementProcedureArguments arguments)
        {
            if (string.IsNullOrEmpty(procedureName))
            {
                throw new ArgumentNullException(nameof(procedureName));
            }

            if (!this.procedures.ContainsKey(procedureName))
            {
                throw new InvalidOperationException($"The specified procedure was not set, use {nameof(this.AddProcedureAsync)} to add a data management procedure: ({procedureName})");
            }

            return this.procedures[procedureName].ExecuteAsync(arguments);
        }
    }
}
