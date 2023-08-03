using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IRetrieveArguments : IArguments
    {
        object Value { get; set; }
    }
}
