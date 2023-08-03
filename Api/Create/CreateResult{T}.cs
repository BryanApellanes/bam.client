using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    /// <summary>
    /// Represents the result of a create request.
    /// </summary>
    /// <typeparam name="T">The type to create.</typeparam>
    public class CreateResult<T> : Result, ICreateResult<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CreateResult{T}"/> class.
        /// </summary>
        /// <param name="arguments"></param>
        public CreateResult(ICreateArguments arguments)
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CreateResult{T}"/> class.
        /// </summary>
        /// <param name="arguments">Arguments to the creation process.</param>
        /// <param name="exception">The exception if one occurred.</param>
        public CreateResult(ICreateArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        /// <summary>
        /// Gets or sets the arguments.
        /// </summary>
        public new ICreateArguments Arguments
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or sets the created object.
        /// </summary>
        public T CreatedObject
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the created object.
        /// </summary>
        object ICreateResult.CreatedObject
        {
            get => CreatedObject;
        }

        /// <summary>
        /// Save the current object.
        /// </summary>
        /// <returns>Task</returns>
        public Task SaveAsync()
        {
            return Task.Run(() => this.SavePending());
        }
    }
}
