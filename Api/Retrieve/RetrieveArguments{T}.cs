using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class RetrieveArguments<T> : RetrieveArguments, IRetrieveArguments<T>
    {
        public new T Value { get; set; }

        T IRetrieveArguments<T>.Value
        {
            get;
            set;
        }
    }
}
