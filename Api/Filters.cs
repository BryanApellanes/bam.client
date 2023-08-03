using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public enum Filters
    {
        Equal,
        GreaterThanOrEqual,
        GreaterThan,
        LessThanOrEqual,
        LessThan,
        NotEqual,
        Present,

        /// <summary>
        /// Has value; same as Present.
        /// </summary>
        HasValue,
        StartsWith
    }
}
