using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class ListResult<T> : Result, IListResult<T>
    {
        public ListResult(IListArguments arguments)
        {
            base.Arguments = arguments;
            this.Arguments = arguments;
            this.OperationSucceeded = true;
        }

        public ListResult(IListArguments arguments, Exception exception)
        {
            this.Arguments = arguments;
            this.OperationSucceeded = false;
            this.Exception = exception;
            this.Message = exception.Message;
        }

        public new IListArguments Arguments
        {
            get;
            set;
        }

        public T[] List
        {
            get;
            set;
        }


        object[] IListResult.List
        {
            get
            {
                List<object> list = new List<object>();
                foreach(T item in List)
                {
                    list.Add(item);
                }
                return list.ToArray();
            }
        }

        public Task SaveAsync()
        {
            return Task.Run(() => SavePending());
        }
    }
}
