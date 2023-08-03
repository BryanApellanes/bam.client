// <copyright file="ICreateArguments.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Bam.Client
{
    /// <summary>
    /// Arguments for a CREATE request.
    /// </summary>
    public interface ICreateArguments : IArguments
    {
        object Value { get; set; }
    }
}
