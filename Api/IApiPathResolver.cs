// <copyright file="IApiPathResolver.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System;

namespace Bam.Client
{
    /// <summary>
    /// Provides paths for API calls.
    /// </summary>
    public interface IApiPathResolver
    {
        /// <summary>
        /// Resolve the URL for the specified arguments.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Path as string.</returns>
        string ResolvePath(IArguments arguments);

        /// <summary>
        /// Resolve the path for the specified type and arguments.
        /// </summary>
        /// <param name="objectType">The type of the object.</param>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Path as string.</returns>
        string ResolvePath(Type objectType, IArguments arguments);

        /// <summary>
        /// Resolve the path for the specified generic type and arguments.
        /// </summary>
        /// <typeparam name="T">The type of the object.</typeparam>
        /// <param name="arguments">The arguments.</param>
        /// <returns>Path as string.</returns>
        string ResolvePath<T>(IArguments arguments);
    }
}
