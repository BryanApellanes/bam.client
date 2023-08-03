using Bam.Sdk.Model;
using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Text;

namespace Bam.Client
{
    public class OpenIdConnectApplicationCreateArguments: CreateArguments<OpenIdConnectApplication>
    {
        public OpenIdConnectApplicationCreateArguments(ApiConfig apiConfig, ProjectArguments projectArguments)
        {
            ApiConfig = apiConfig;
            ProjectArguments = projectArguments;
        }

        public ProjectArguments ProjectArguments
        {
            get
            {
                return GetArgument<ProjectArguments>();
            }
            set
            {
                SetArgument(value);
            }
        }
    }
}
