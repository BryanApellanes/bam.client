using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class QFilter : IFilterSegment
    {
        public QFilter(string value)
        {
            this.Value = value;
        }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"q={Value}";
        }
    }
}
