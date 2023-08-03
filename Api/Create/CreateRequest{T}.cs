using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    /// <summary>
    /// A request to create data.
    /// </summary>
    /// <typeparam name="T">The type of the data to create.</typeparam>
    public class CreateRequest<T> : ICreateRequest<T>
    {

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateRequest{T}"/> class.
        /// </summary>
        /// <param name="arguments">The arguments.</param>
        /// <param name="toCreate">The value to create.</param>
        public CreateRequest(ICreateArguments arguments, T toCreate)
        {
            this.Arguments = arguments;
            this.Data = toCreate;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        public T Data
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        public ICreateArguments Arguments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the data.
        /// </summary>
        object ICreateRequest.Data
        {
            get
            {
                return this.Data;
            }

            set
            {
                this.Data = (T)value;
            }
        }
    }
}
