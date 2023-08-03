using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class DataManagementProcedureArguments : Arguments, IDataManagementProcedureArguments
    {
        public DataManagementProcedureArguments(IDataManagementContext context, string procedureName)
        {
            this.Context = context;
            this.ProcedureName = procedureName;
        }

        public string ProcedureName
        {
            get
            {
                return this.GetArgument<string>(nameof(ProcedureName));
            }
            set
            {
                this.SetArgument(nameof(ProcedureName), value);
            }
        }

        public IDataManagementContext Context
        {
            get
            {
                return this.GetArgument<IDataManagementContext>(nameof(Context));
            }
            set
            {
                this.SetArgument(nameof(Context), value);
            }
        }

        public IDataManagementProcedureArguments Copy(string newProcedureName)
        {
            DataManagementProcedureArguments result = new DataManagementProcedureArguments(this.Context, newProcedureName);
            result.Copy(this);
            result.ProcedureName = newProcedureName;
            return result;
        }
    }
}
