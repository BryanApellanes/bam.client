using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bam.Client
{
    public class DataManagementProcedureResult : Result, IDataManagementProcedureResult
    {
        List<IResult> results;
        List<ICreateResult> createResults;
        List<IRetrieveResult> retrieveResults;
        List<IUpdateResult> updateResults;
        List<IDeleteResult> deleteResults;
        List<ISearchResult> searchResults;
        List<IOperationResult> operationResults;
        public DataManagementProcedureResult()
        {
            this.results = new List<IResult>();
            this.createResults = new List<ICreateResult>();
            this.retrieveResults = new List<IRetrieveResult>();
            this.updateResults = new List<IUpdateResult>();
            this.deleteResults = new List<IDeleteResult>();
            this.searchResults = new List<ISearchResult>();
            this.operationResults = new List<IOperationResult>();
        }

        public DataManagementProcedureResult(Exception ex) : this()
        { 
            this.operationSucceeded = false;
            this.Exception = ex;
            this.Message = ex.Message;            
        }

        bool? operationSucceeded;
        public override bool OperationSucceeded
        {
            get
            {
                if(operationSucceeded != null && operationSucceeded.HasValue)
                {
                    return operationSucceeded.Value;
                }
                return results.Any(r => r.OperationSucceeded == false) ? false: true;
            }
            set 
            {
                operationSucceeded = value;
            }
        }

        Exception exception;
        public override Exception Exception
        {
            get
            {
                if(exception != null)
                {
                    return exception;
                }
                return new AggregateException(results.Select(r => r.Exception).ToArray());
            }
            set
            {
                this.exception = value;
            }
        }

        public string ProcedureName
        {
            get;
            set;
        }

        public IResult Result
        {
            get;
            set;
        }

        public IList<IResult> Results
        {
            get
            {
                return results;
            }
        }

        public IList<ICreateResult> CreateResults
        {
            get
            {
                return createResults;
            }
        }

        public IList<IRetrieveResult> RetrieveResults
        {
            get
            {
                return retrieveResults;
            }
        }

        public IList<IUpdateResult> UpdateResults
        {
            get
            {
                return updateResults;
            }
        }

        public IList<IDeleteResult> DeleteResults
        {
            get
            {
                return deleteResults;
            }
        }

        public IList<ISearchResult> SearchResults
        {
            get
            {
                return searchResults;
            }
        }

        public IList<IOperationResult> OperationResults
        {
            get
            {
                return operationResults;
            }
        }

        IDataManagementProcedureArguments arguments;
        public new IDataManagementProcedureArguments Arguments
        {
            get
            {
                return arguments;
            }
            set
            {
                arguments = value;
                base.Arguments = value;
            }
        }

        public void CombineWith(IDataManagementProcedureResult other)
        {
            IResult currentResult = this.Result;
            foreach(IResult result in other.Results)
            {
                this.AddResult(result);
            }
            this.Result = currentResult;
        }

        public IResult GetResult(int index = -1)
        {
            if (index == -1)
            {
                index = results.Count - 1;
            }
            if (results.Count > index)
            {
                return results[index];
            }
            return null;
        }

        public T GetCreated<T>(int index = -1)
        {
            if (index == -1)
            {
                index = createResults.Count - 1;
            }
            if (createResults.Count > index)
            {
                return (T)createResults[index].CreatedObject;
            }
            return default;
        }

        public void AddResult(IResult result)
        {
            this.Result = result;
            this.Results.Add(result);

            if (result is ICreateResult createResult)
            {
                createResults.Add(createResult);
            }
            if (result is IRetrieveResult retrieveResult)
            {
                retrieveResults.Add(retrieveResult);
            }
            if (result is IUpdateResult updateResult)
            {
                updateResults.Add(updateResult);
            }
            if (result is IDeleteResult deleteResult)
            {
                deleteResults.Add(deleteResult);
            }
            if (result is ISearchResult searchResult)
            {
                searchResults.Add(searchResult);
            }
            if (result is IOperationResult operationResult)
            {
                operationResults.Add(operationResult);
            }
        }
    }
}
