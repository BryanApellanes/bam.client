using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class DeleteArguments<T> : DeleteArguments, IDeleteArguments<T>
    {
        public new T Value { get; set; }

        T IDeleteArguments<T>.Value
        {
            get;
            set;
        }
    }
}
