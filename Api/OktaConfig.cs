using System;
using System.Collections.Generic;
using System.Text;
using YamlDotNet.Serialization;

namespace Bam.Client
{
    /// <summary>
    /// Represents the "Bam" node of the Sdk configuration.
    /// </summary>
    public class BamConfig
    {
        [YamlMember(Alias = "orgUrl")]
        public string OrgUrl { get; set; }

        [YamlMember(Alias = "token")]
        public string Token { get; set; }

        [YamlIgnore]
        public string Domain
        {
            get
            {
                if (!string.IsNullOrEmpty(OrgUrl))
                {
                    Uri uri = new Uri(OrgUrl);
                    return uri.Host;
                }
                return string.Empty;
            }
        }
    }
}
