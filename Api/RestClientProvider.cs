using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class RestClientProvider : IRestClientProvider
    {
        public RestClientProvider(ApiConfig config)
        {
            this.Config = config;
        }

        public ApiConfig Config { get; set; }
        public JsonSerializerSettings SerializerSettings { get; set; } = new JsonSerializerSettings
        {
            // OpenAPI generated types generally hide default constructors.
            ConstructorHandling = ConstructorHandling.AllowNonPublicDefaultConstructor,
            ContractResolver = new DefaultContractResolver
            {
                NamingStrategy = new CamelCaseNamingStrategy
                {
                    OverrideSpecifiedNames = false
                }
            },
            NullValueHandling = NullValueHandling.Ignore,
        };

        public RestClient GetClient()
        {
            return GetClient(Config);
        }

        public RestClient GetClient(ApiConfig config)
        {
            return GetClient(config.OrgUrl);
        }

        public RestClient GetClient(string baseUrl)
        {
            return new RestClient(baseUrl, configureSerialization: s => s.UseSerializer(() => new ApiSerializer()));
        }
    }
}
