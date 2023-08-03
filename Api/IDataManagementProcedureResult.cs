using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IDataManagementProcedureResult : IResult
    {
        string ProcedureName { get; }
        IResult Result { get; }
        IList<IResult> Results { get; }

        void AddResult(IResult result);
        IResult GetResult(int index = -1);
        T GetCreated<T>(int index = -1);

        IList<ICreateResult> CreateResults { get; }
        IList<IRetrieveResult> RetrieveResults { get; }
        IList<IUpdateResult> UpdateResults { get; }
        IList<IDeleteResult> DeleteResults { get; }
        IList<ISearchResult> SearchResults { get; }
        IList<IOperationResult> OperationResults { get; }

        new IDataManagementProcedureArguments Arguments { get; }
        void CombineWith(IDataManagementProcedureResult other);
    }
}
