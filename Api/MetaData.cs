using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class MetaData : IMetaData
    {

        public string Path { get; }

        public Type Type { get; set; }

        public object For { get; set; }

        public static string ValueAsPathParameter(object parameter)
        {
            return ApiConfig.ConvertToString(parameter);
        }

        public string GetPath(IArguments arguments)
        {
            throw new NotImplementedException();
        }
    }
}
