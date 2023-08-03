using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    internal class Not : IFilterSegment
    {
        public override string ToString()
        {
            return "NOT";
        }
    }
}
