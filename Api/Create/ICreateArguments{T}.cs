// <copyright file="ICreateArguments{T}.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Bam.Client
{
    public interface ICreateArguments<T> : ICreateArguments, IArguments<T>
    {
        new T Value { get; set; }
    }
}
