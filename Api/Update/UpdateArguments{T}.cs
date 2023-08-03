using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class UpdateArguments<T> : UpdateArguments, IUpdateArguments<T>
    {
        public UpdateArguments(T value): base(value)
        {
            Value = value;
        }

        public new T Value { get; set; }

        T IUpdateArguments<T>.Value
        {
            get;
            set;
        }
    }
}
