using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IDataManagementProcedureResult<T> : IDataManagementProcedureResult
    {
        new T Result { get; set; }
    }
}
