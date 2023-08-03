// <copyright file="IDataManagementProcedureArguments.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Bam.Client
{
    /// <summary>
    /// Arguments provided to a procedure exection.
    /// </summary>
    public interface IDataManagementProcedureArguments : IArguments
    {
        /// <summary>
        /// Gets or sets the name of the procedure.
        /// </summary>
        string ProcedureName { get; set; }

        /// <summary>
        /// Gets or sets the context.
        /// </summary>
        IDataManagementContext Context { get; set; }

        /// <summary>
        /// Copy this instance with a new procedure name.
        /// </summary>
        /// <param name="newProcedureName">The procedure name applied to the new instance.</param>
        /// <returns>IDataManagementProcedureArguments</returns>
        IDataManagementProcedureArguments Copy(string newProcedureName);
    }
}
