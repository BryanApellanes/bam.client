using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ListArguments<T> : ListArguments, IListArguments<T>
    {
        public override Type Type
        {
            get
            {
                return typeof(T);
            }
            set
            {
                // can't set Type on generic 
            }
        }
    }
}
