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
    public class DeleteArguments : Arguments, IDeleteArguments
    {
        public object Value { get; set; }
    }
}
