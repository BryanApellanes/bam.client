using Bam.Sdk.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Bam.Client
{
    public class ApiClient : IClient
    {
        public ApiClient(ApiConfig config)
        {
            this.ApiConfig = config;
            this.RestClientProvider = new RestClientProvider(config);
        }

        public ApiConfig ApiConfig { get; set; }
        public IRestClientProvider RestClientProvider { get; set; }
        public async Task<IResponse<T>> DeleteAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Delete, path), config, cancellationToken);
        }

        public async Task<IResponse> DeleteAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Delete, path), config, cancellationToken);
        }

        public async Task<IResponse<T>> GetAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Get, path), config, cancellationToken);
        }

        public async Task<IResponse> GetAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Get, path), config, cancellationToken);
        }

        public async Task<IResponse<T>> HeadAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Head, path), config, cancellationToken);
        }

        public async Task<IResponse> HeadAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Head, path), config, cancellationToken);
        }

        public async Task<IResponse<T>> OptionsAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Options, path), config, cancellationToken);
        }

        public async Task<IResponse> OptionsAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Options, path), config, cancellationToken);
        }

        public async Task<IResponse<T>> PatchAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Patch, path), config, cancellationToken);
        }

        public async Task<IResponse> PatchAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Patch, path), config, cancellationToken);
        }

        public async Task<IResponse<T>> PostAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Post, path), config, cancellationToken);
        }

        public async Task<IResponse> PostAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Post, path), config, cancellationToken);
        }

        public async Task<IResponse<T>> PutAsync<T>(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync<T>(parameters.CreateRequest(HttpMethod.Put, path), config, cancellationToken);
        }

        public async Task<IResponse> PutAsync(string path, RequestParameters parameters, ApiConfig configuration = null, CancellationToken cancellationToken = default)
        {
            ApiConfig config = configuration ?? ApiConfig.Global;
            return await ExecuteAsync(parameters.CreateRequest(HttpMethod.Put, path), config, cancellationToken);
        }

        protected virtual async Task<IResponse> ExecuteAsync(RestRequest request, ApiConfig config, CancellationToken cancellationToken = default)
        {
            if (ApiConfig.IsPrivateKeyMode)
            {
                return await ExecutePrivateKeyMode(request, config, cancellationToken);
            }

            RestClient restClient = RestClientProvider.GetClient(config);
            RestResponse response = await restClient.ExecuteAsync(request, cancellationToken);
            return ConvertResponse(response);
        }

        protected virtual async Task<IResponse<T>> ExecuteAsync<T>(RestRequest request, ApiConfig config, CancellationToken cancellationToken = default)
        {
            if (ApiConfig.IsPrivateKeyMode)
            {
                return await ExecutePrivateKeyMode<T>(request, config, cancellationToken);
            }

            RestClient restClient = RestClientProvider.GetClient(config);
            RestResponse<T> response = await restClient.ExecuteAsync<T>(request, cancellationToken);
            return ConvertResponse(response);
        }

        protected virtual async Task<IResponse<T>> ExecutePrivateKeyMode<T>(RestRequest request, ApiConfig config, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PrivateKeyMode not currently supported by this client");
        }

        protected virtual async Task<IResponse> ExecutePrivateKeyMode(RestRequest request, ApiConfig config, CancellationToken cancellationToken = default)
        {
            throw new NotSupportedException("PrivateKeyMode not currently supported by this client");
        }

        private Response<T> ConvertResponse<T>(RestResponse<T> restResponse)
        {
            Response<T> response = new Response<T>(restResponse.StatusCode, restResponse.Content);
            response.Data = restResponse.Data;
            CopyHeaders(response, restResponse);
            CopyCookies(response, restResponse);

            return response;
        }

        private Response ConvertResponse(RestResponse restResponse)
        {
            Response response = new Response(restResponse.StatusCode, restResponse.Content);
            CopyHeaders(response, restResponse);
            CopyCookies(response, restResponse);

            return response;
        }

        private void CopyHeaders(Response to, RestResponse from)
        {
            if (from.Headers != null)
            {
                foreach (Parameter header in from.Headers)
                {
                    to.Headers.Add(header.Name, ApiConfig.ConvertToString(header.Value));
                }
            }
        }

        private void CopyCookies(Response to, RestResponse from)
        {
            if (from.Cookies != null)
            {
                foreach (Cookie cookie in from.Cookies)
                {
                    to.Cookies.Add(cookie);
                }
            }
        }
    }
}
