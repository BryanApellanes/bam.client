using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ApiConfiguration : Configuration
    {
        public static implicit operator ApiConfig(ApiConfiguration config)
        {
            return new ApiConfig(config.BamDomain, config.Token);
        }

        public static implicit operator ApiConfiguration(ApiConfig config)
        {
            return new ApiConfiguration(config.Domain, config.Token);
        }

        public ApiConfiguration(string BamDomain, string token): base(BamDomain, token) 
        {
        }
    }
}
