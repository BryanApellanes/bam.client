using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    internal class Or : IFilterSegment
    {
        public override string ToString()
        {
            return " OR ";
        }
    }
}
