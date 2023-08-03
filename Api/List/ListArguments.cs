using Bam.Wizard.CommandLine;
using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;
using YamlDotNet.Core.Events;

namespace Bam.Client
{
    /// <summary>
    /// Arguments provided to a list operation, an operation that returns a list of items.
    /// </summary>
    public class ListArguments : Arguments, IListArguments
    {
        public virtual Type Type { get; set; }

        /// <inheritdoc/>
        public FilterSet FilterParameter
        {
            get
            {
                return this.GetArgument<FilterSet>();
            }

            set
            {
                this.SetArgument(value);
            }
        }

        public SearchFilterSet SearchParameter
        {
            get
            {
                return GetArgument<SearchFilterSet>();
            }

            set
            {
                SetArgument(value);
            }
        }

        public QFilter QParameter
        {
            get
            {
                return GetArgument<QFilter>();
            }
            set
            {
                SetArgument(value);
            }
        }

        public FilterSet Filter(string propertyName)
        {
            FilterSet filterSet = FilterParameter;
            if (filterSet == null)
            {
                filterSet = new FilterSet().Where(propertyName);
                FilterParameter = filterSet;
            }
            return filterSet;
        }

        public SearchFilterSet Search(string propertyName)
        {
            SearchFilterSet filterSet = SearchParameter;
            if(filterSet == null)
            {
                filterSet = new SearchFilterSet().Where(propertyName);
                SearchParameter = filterSet;
            }
            return filterSet;
        }

        public QFilter Q(string value)
        {
            QFilter qFilter = QParameter;
            if(qFilter == null)
            {
                qFilter = new QFilter(value);
                QParameter = qFilter;
            }
            return qFilter;
        }
    }
}
