using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    /// <summary>
    /// Encapsulates arguments provided to an API call.
    /// </summary>
    public interface IArguments
    {
        /// <summary>
        /// Gets or sets the ApiConfig.
        /// </summary>
        ApiConfig ApiConfig { get; set; }

        /// <summary>
        /// Gets or sets the named argument.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        /// <returns>Argument as object.</returns>
        object this[string name] { get; set; }

        /// <summary>
        /// Gets the named arguments.
        /// </summary>
        /// <param name="name">The name of the argument.</param>
        /// <returns>Argument as object.</returns>
        object GetArgument(string name);

        /// <summary>
        /// Gets the argument of the specified generic type.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <returns>Argument as T.</returns>
        T GetArgument<T>();

        /// <summary>
        /// Gets the argument of the specified generic type.
        /// </summary>
        /// <typeparam name="T">The type of the argument.</typeparam>
        /// <param name="name">The name given to the argument when SetArgument was called.</param>
        /// <returns>Argument as T.</returns>
        T GetArgument<T>(string name);

        void SetArgument<T>(T value);

        void SetArgument<T>(string name,  T value);

        void AddPathArgument(string name, string value);

        Dictionary<string, string> GetPathArguments();

        /// <summary>
        /// Copy the current instance as a new argument type.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        T Copy<T>() where T : Arguments, new();
    }
}
