using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public interface IRestClientProvider
    {
        RestClient GetClient();

        RestClient GetClient(ApiConfig config);

        RestClient GetClient(string url);
    }
}
