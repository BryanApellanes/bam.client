using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class SearchFilterSet : FilterSet
    {
        public SearchFilterSet() 
        {
            this.Kind = FilterKind.Search;
        }

        public new SearchFilterSet Where(string propertyName)
        {
            return new SearchFilterSet() { Current = new FilterExpression() { Property = propertyName } };
        }
    }
}
