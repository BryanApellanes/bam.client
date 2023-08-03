using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public abstract class Arguments : IArguments
    {
        Dictionary<string, object> arguments;
        Dictionary<string, string> pathArguments;
        public Arguments()
        {
            this.arguments = new Dictionary<string, object>();
            this.pathArguments = new Dictionary<string, string>();
        }

        public object GetArgument(string name)
        {
            return this.arguments[name];
        }

        public T GetArgument<T>()
        {
            return this.GetArgument<T>(typeof(T).FullName);
        }

        public T GetArgument<T>(string name)
        {
            if (!this.arguments.ContainsKey(name))
            {
                return default(T);
            }

            return (T)this.arguments[name];
        }

        public void SetArgument<T>(T value)
        {
            SetArgument<T>(typeof(T).FullName, value);
        }

        public void SetArgument<T>(string name, T value)
        {
            this.arguments[name] = value;
        }


        public void AddPathArgument(string name, string value)
        {
            this.pathArguments[name] = value;
        }

        public Dictionary<string, string> GetPathArguments()
        {
            return this.pathArguments;
        }

        public object this[string name]
        {
            get
            {
                return this.arguments[name];
            }
            set
            {
                this.arguments[name] = value;
            }
        }

        public ApiConfig ApiConfig { get; set; }

        /// <inheritdoc />
        public T Copy<T>() where T : Arguments, new()
        {
            T result = new T();
            result.Copy(this);
            return result;
        }

        public void Copy(Arguments arguments)
        {
            foreach(string key in arguments.arguments.Keys)
            {
                this.arguments[key] = arguments.arguments[key];
            }
        }
    }
}
