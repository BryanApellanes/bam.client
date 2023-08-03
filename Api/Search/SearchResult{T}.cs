using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class SearchResult<T> : Result, ISearchResult<T>
    {
        public SearchResult(ISearchArguments arguments)
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }
        public SearchResult(ISearchArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        public new ISearchArguments Arguments
        {
            get;
            set;
        }

        public T SearchdObject
        {
            get;
            set;
        }

        object ISearchResult.SearchdObject
        {
            get => SearchdObject;
        }

        public Task SaveAsync()
        {
            return Task.Run(() => SavePending());
        }
    }
}
