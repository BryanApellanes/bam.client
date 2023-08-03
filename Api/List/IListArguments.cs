using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IListArguments : IArguments
    {
        Type Type { get; set; }

        FilterSet FilterParameter { get; set; }

        SearchFilterSet SearchParameter { get; set; }

        QFilter QParameter {get;set; }
    }
}
