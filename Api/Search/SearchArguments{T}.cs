using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class SearchArguments<T> : SearchArguments, ISearchArguments<T>
    {
        public new T Value { get; set; }

        T ISearchArguments<T>.Value
        {
            get;
            set;
        }
    }
}
