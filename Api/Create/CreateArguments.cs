// <copyright file="CreateArguments.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

namespace Bam.Client
{
    /// <summary>
    /// Arguments provided to a <see cref="ICreateRequest" />.
    /// </summary>
    public class CreateArguments : Arguments, ICreateArguments
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateArguments"/> class.
        /// </summary>
        public CreateArguments() { }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateArguments"/> class.
        /// </summary>
        /// <param name="value">The value to create.</param>
        public CreateArguments(object value)
        {
            this.Value = value;
        }

        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public object Value
        {
            get
            {
                return this.GetArgument("Value");
            }

            set
            {
                this.SetArgument("Value", value);
            }
        }
    }
}
