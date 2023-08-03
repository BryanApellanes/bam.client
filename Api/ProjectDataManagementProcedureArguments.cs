using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ProjectDataManagementProcedureArguments : DataManagementProcedureArguments
    {
        public ProjectDataManagementProcedureArguments(IDataManagementContext context, string procedureName, ProjectArguments projectArguments, UserRegistration registration) : base(context, procedureName)
        {
            this.ProjectArguments = projectArguments;
            this.UserRegistration = registration;
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

        public UserRegistration UserRegistration
        {
            get
            {
                return GetArgument<UserRegistration>();
            }
            set
            {
                SetArgument(value);
            }
        }
    }
}
