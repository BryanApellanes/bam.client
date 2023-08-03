// <copyright file="CreateArguments{T}.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Bam.Client
{
    /// <summary>
    /// Arguments provided to a <see cref="ICreateRequest" />.
    /// </summary>
    /// <typeparam name="T">The type of the value to create.</typeparam>
    public class CreateArguments<T> : CreateArguments, ICreateArguments<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateArguments{T}"/> class.
        /// </summary>
        public CreateArguments() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateArguments{T}"/> class.
        /// </summary>
        /// <param name="value">The value to create.</param>
        public CreateArguments(T value)
            : base(value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public new T Value
        {
            get
            {
                return this.GetArgument<T>("Value");
            }

            set
            {
                this.SetArgument("Value", value);
            }
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        T ICreateArguments<T>.Value
        {
            get;
            set;
        }
    }
}
