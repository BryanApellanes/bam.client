using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Bam.Client
{
    public struct Filter
    {
        private static readonly Dictionary<Filters, Filter> filters;
        static Filter()
        {
            filters = new Dictionary<Filters, Filter>()
            {
                { Filters.Equal, new Filter("eq", "The attribute and operand values must be identical for a match.") },
                { Filters.GreaterThanOrEqual, new Filter("ge", "If the attribute value is greater than or equal to the operand value, there is a match. The actual comparison depends on the attribute type. String attribute types are a lexicographical comparison and Date types are a chronological comparison.") },
                { Filters.GreaterThan, new Filter("gt", "If the attribute value is greater than operand value, there is a match. The actual comparison depends on the attribute type. String attribute types are a lexicographical comparison and Date types are a chronological comparison.") },
                { Filters.LessThanOrEqual, new Filter("le", "If the attribute value is less than or equal to the operand value, there is a match. The actual comparison depends on the attribute type. String attribute types are a lexicographical comparison and Date types are a chronological comparison.") },
                { Filters.LessThan, new Filter("lt", "If the attribute value is less than operand value, there is a match. The actual comparison depends on the attribute type. String attribute types are a lexicographical comparison and Date types are a chronological comparison.") },
                { Filters.NotEqual, new Filter("ne", "If the attribute value does not match the operand value, there is a match.") },
                { Filters.Present, new Filter("pr", "If the attribute has a non-empty value or if it contains a non-empty node for complex attributes, there is a match.") },
                { Filters.HasValue, new Filter("pr", "If the attribute has a non-empty value or if it contains a non-empty node for complex attributes, there is a match.") },
                { Filters.StartsWith, new Filter("sw", "The entire operand value must be a substring of the attribute value that starts at the beginning of the attribute value. This criterion is satisfied if the two strings are identical.") }
            };
        }
        
        public static implicit operator string(Filter filter)
        {
            return filter.Name;
        }

        public Filter(string name, string description)
        {
            this.Name = name;
            this.Description = description;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public override string ToString()
        {
            return Name;
        }

        public static Filter Equal
        {
            get
            {
                return filters[Filters.Equal];
            }
        }

        public static Filter GreaterThanOrEqual
        {
            get
            {
                return filters[Filters.GreaterThanOrEqual];
            }
        }

        public static Filter GreaterThan
        {
            get
            {
                return filters[Filters.GreaterThan];
            }
        }

        public static Filter LessThanOrEqual
        {
            get
            {
                return filters[Filters.LessThanOrEqual];
            }
        }

        public static Filter LessThan
        {
            get
            {
                return filters[Filters.LessThan];
            }
        }

        public static Filter NotEqual
        {
            get
            {
                return filters[Filters.NotEqual];
            }
        }

        public static Filter HasValue
        {
            get
            {
                return filters[Filters.HasValue];
            }
        }

        public static Filter Present
        {
            get
            {
                return filters[Filters.Present];
            }
        }

        public static Filter StartsWith
        {
            get
            {
                return filters[Filters.StartsWith];
            }
        }
    }
}
