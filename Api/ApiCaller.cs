using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public abstract class ApiCaller : LogEventWriter, IApiCaller
    {
        public ApiCaller(ApiConfig sdkConfig, IDataManagementContext dataManagementContext, IOAuthTokenProvider authTokenProvider = null)
        {
            this.ApiConfig = sdkConfig;
            this.DataManagementContext = dataManagementContext;
            this.OAuthTokenProvider = authTokenProvider;
            this.ApiClient = new ApiClient(sdkConfig);
        }

        protected Sdk.Client.HttpMethod HttpMethod { get; set; }

        protected IDataManagementContext DataManagementContext { get; set; }

        public ApiConfig ApiConfig { get; protected set; }

        public IOAuthTokenProvider OAuthTokenProvider { get; protected set; }

        public IApiPathResolver ApiPathResolver 
        {
            get
            {
                return DataManagementContext?.ApiPathResolver;
            } 
        }

        public ApiClient ApiClient { get; protected set; }

        protected static void HandlePathArguments(IArguments args, RequestParameters requestParameters)
        {
            Dictionary<string, string> pathArguments = args.GetPathArguments();
            foreach (string key in pathArguments.Keys)
            {
                requestParameters.PathParameters.Add(key, pathArguments[key]);
            }
        }

        protected virtual async Task<IResponse> CallApiAsync(Sdk.Client.HttpMethod method, string path, RequestParameters parameters, ApiConfig apiConfig, CancellationToken cancellationToken = default)
        {
            switch (method)
            {
                case Sdk.Client.HttpMethod.Post:
                    return await ApiClient.PostAsync(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Get:
                    return await ApiClient.GetAsync(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Put:
                    return await ApiClient.PutAsync(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Delete:
                    return await ApiClient.DeleteAsync(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Head:
                    return await ApiClient.HeadAsync(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Options:
                    return await ApiClient.OptionsAsync(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Patch:
                    return await ApiClient.PatchAsync(path, parameters, apiConfig);
                default:
                    return await ApiClient.GetAsync(path, parameters, apiConfig);
            }
        }

        protected virtual async Task<IResponse<T>> CallApiAsync<T>(Sdk.Client.HttpMethod method, string path, RequestParameters parameters, ApiConfig apiConfig, CancellationToken cancellationToken = default)
        {
            switch (method)
            {
                case Sdk.Client.HttpMethod.Post:
                    return await ApiClient.PostAsync<T>(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Get:
                    return await ApiClient.GetAsync<T>(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Put:
                    return await ApiClient.PutAsync<T>(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Delete:
                    return await ApiClient.DeleteAsync<T>(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Head:
                    return await ApiClient.HeadAsync<T>(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Options:
                    return await ApiClient.OptionsAsync<T>(path, parameters, apiConfig);
                case Sdk.Client.HttpMethod.Patch:
                    return await ApiClient.PatchAsync<T>(path, parameters, apiConfig);
                default:
                    return await ApiClient.GetAsync<T>(path, parameters, apiConfig);
            }
        }

        protected virtual async Task<IResponse> CallApiAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            return await CallApiAsync(HttpMethod, path, parameters, configuration, cancellationToken);
        }

        protected virtual async Task<IResponse<T>> CallApiAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            return await CallApiAsync<T>(HttpMethod, path, parameters, configuration, cancellationToken);
        }

        protected async Task<RequestParameters> GetRequestParametersAsync(ApiConfig apiConfig)
        {
            RequestParameters requestParameters = new RequestParameters();
            requestParameters.HeaderParameters.Add("User-Agent", string.IsNullOrEmpty(apiConfig.UserAgent) ? BamWizard.GetUserAgent() : apiConfig.UserAgent);
            requestParameters.HeaderParameters.Add("Content-Type", "application/json");
            requestParameters.HeaderParameters.Add("Accept", "application/json");            

            Configuration configuration = (Configuration)apiConfig;
            if (Configuration.IsSswsMode(configuration))
            {
                requestParameters.HeaderParameters.Add("Authorization", $"SSWS {configuration.Token}");
            }
            if (Configuration.IsBearerTokenMode(configuration))
            {
                requestParameters.HeaderParameters.Add("Authorization", $"Bearer {configuration.AccessToken}");
            }
            if (Configuration.IsPrivateKeyMode(configuration) && !requestParameters.HeaderParameters.ContainsKey("Authorization"))
            {
                string token = await OAuthTokenProvider.GetAccessTokenAsync();
                requestParameters.HeaderParameters.Add("Authorization", $"Bearer {token}");
            }
            return requestParameters;
        }

        protected bool IsSuccessCode(IResponse response)
        {
            int statusCode = (int)response.StatusCode;
            return statusCode >= 200 && statusCode <= 299;
        }
    }
}
