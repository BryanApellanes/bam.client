using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class FilterExpression : IFilterSegment
    {
        public string Property { get; set; }
        public Filter Filter { get; set; }

        public string Value { get; set; }

        public override string ToString()
        {
            return $"{Property} {Filter} \"{Value}\"";
        }
    }
}
