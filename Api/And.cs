using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    internal class And : IFilterSegment
    {
        public override string ToString()
        {
            return "AND";
        }
    }
}
