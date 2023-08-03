// <copyright file="FilterSet.cs" company="Bam, Inc">
// Copyright (c) 2020 - present Bam, Inc. All rights reserved.
// Licensed under the Apache 2.0 license. See the LICENSE file in the project root for full license information.
// </copyright>

using System.Collections.Generic;

namespace Bam.Client
{
    public class FilterSet
    {
        public FilterSet()
        {
            this.Kind = FilterKind.Filter;
        }

        public FilterKind Kind { get; set; }

        public IList<IFilterSegment> Filters { get; set; } = new List<IFilterSegment>();

        private FilterExpression current;

        protected internal FilterExpression Current 
        {
            get
            {
                return current;
            }

            set
            {
                Filters.Add(value);
                current = value;
            }
        }

        public FilterSet Where(string propertyName)
        {
            return new FilterSet() { Current = new FilterExpression() { Property = propertyName } };
        }

        public FilterSet Equal(string value)
        {
            Current.Filter = Filter.Equal;
            Current.Value = value;
            return this;
        }

        public FilterSet GreaterThanOrEqual(string value)
        {
            Current.Filter = Filter.GreaterThanOrEqual;
            Current.Value = value;
            return this;
        }

        public FilterSet GreaterThan(string value)
        {
            Current.Filter = Filter.GreaterThan;
            Current.Value = value;
            return this;
        }

        public FilterSet LessThanOrEqual(string value)
        {
            Current.Filter = Filter.LessThanOrEqual;
            Current.Value = value;
            return this;
        }

        public FilterSet LessThan(string value)
        {
            Current.Filter = Filter.LessThan;
            Current.Value = value;
            return this;
        }

        public FilterSet NotEqual(string value)
        {
            Current.Filter = Filter.NotEqual;
            Current.Value = value;
            return this;
        }

        public FilterSet Present(string value)
        {
            Current.Filter = Filter.Present;
            Current.Value = value;
            return this;
        }

        public FilterSet HasValue(string value)
        {
            Current.Filter = Filter.HasValue;
            Current.Value = value;
            return this;
        }

        public FilterSet StartsWith(string value)
        {
            Current.Filter = Filter.StartsWith;
            Current.Value = value;
            return this;
        }

        public FilterSet And(string propertyName)
        {
            Filters.Add(new And());
            Current = new FilterExpression() { Property = propertyName };
            return this;
        }

        public FilterSet Or(string propertyName)
        {
            Filters.Add(new Or());
            Current = new FilterExpression() { Property = propertyName };
            return this;
        }

        public FilterSet Not(string propertyName)
        {
            Filters.Add(new Not());
            Current = new FilterExpression() { Property = propertyName };
            return this;
        }

        public override string ToString()
        {
            return $"{this.Kind.ToString().ToLowerInvariant()}={this.ValueToString()}";
        }

        public string ValueToString()
        {
            return string.Join(" ", Filters);
        }
    }
}
