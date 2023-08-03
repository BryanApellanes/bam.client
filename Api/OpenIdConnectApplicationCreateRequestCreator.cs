using Newtonsoft.Json;
using Bam.Sdk.Model;
using Bam.Wizard.Logging;
using Bam.Wizard.VisualStudio;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class OpenIdConnectApplicationCreateRequestCreator : LogEventWriter, ICreateRequestCreator<OpenIdConnectApplication>
    {
        CreateRequestCreator<OpenIdConnectApplication> requestCreator;
        public OpenIdConnectApplicationCreateRequestCreator(ICreateDataProvider<OpenIdConnectApplication> dataProvider, ILogger logger = null) : base(logger)
        {
            this.requestCreator = new CreateRequestCreator<OpenIdConnectApplication>(dataProvider);
        }

        public Task<ICreateRequest<OpenIdConnectApplication>> CreateRequestAsync(ICreateArguments arguments)
        {
            return requestCreator.CreateRequestAsync(arguments);
        }

        public Task<OpenIdConnectApplication> GetDefinitionAsync(ICreateArguments arguments)
        {
            return requestCreator.GetDefinitionAsync(arguments);
        }
    }
}
