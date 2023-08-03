using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public static class RestRequestExtensions
    {
        public static RestRequest AddFile(this RestRequest req, FileParameter f)
        {
            return req.AddFile(f.Name, () => f.GetFile(), f.FileName, f.ContentType);
        }
    }
}
