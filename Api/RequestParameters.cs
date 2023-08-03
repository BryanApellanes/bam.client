using Bam.Sdk.Client;
using RestSharp;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace Bam.Client
{
    public class RequestParameters
    {
        /// <summary>
        /// Constructs a new instance of <see cref="RequestParameters"/>
        /// </summary>
        public RequestParameters()
        {
            PathParameters = new Dictionary<string, string>();
            QueryParameters = new Multimap<string, string>();
            HeaderParameters = new Multimap<string, string>();
            FormParameters = new Dictionary<string, string>();
            FileParameters = new Multimap<string, Stream>();
            Cookies = new List<Cookie>();
        }

        /// <summary>
        /// Parameters to be bound to path parts of the Request's URL
        /// </summary>
        public Dictionary<string, string> PathParameters { get; set; }

        /// <summary>
        /// Query parameters to be applied to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        public Multimap<string, string> QueryParameters { get; set; }

        /// <summary>
        /// Header parameters to be applied to to the request.
        /// Keys may have 1 or more values associated.
        /// </summary>
        public Multimap<string, string> HeaderParameters { get; set; }

        /// <summary>
        /// Form parameters to be sent along with the request.
        /// </summary>
        public Dictionary<string, string> FormParameters { get; set; }

        /// <summary>
        /// File parameters to be sent along with the request.
        /// </summary>
        public Multimap<string, Stream> FileParameters { get; set; }

        /// <summary>
        /// Cookies to be sent along with the request.
        /// </summary>
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// Any data associated with a request body.
        /// </summary>
        public object Data { get; set; }

        public RestRequest CreateRequest(HttpMethod method, string path, Dictionary<string, string> defaultHeaders = null)
        {
            if (path == null) throw new ArgumentNullException(nameof(path));

            RestRequest request = new RestRequest(path, ConvertMethod(method));

            if (PathParameters != null)
            {
                HandlePathParameters(request);
            }

            if (QueryParameters != null)
            {
                HandleQueryParameters(request);
            }

            if (defaultHeaders != null)
            {
                HandleDefaultHeaders(defaultHeaders, request);
            }

            if (HeaderParameters != null)
            {
                HandleHeaderParameters(request);
            }

            if (FormParameters != null)
            {
                HandleFormParameters(request);
            }

            if (Data != null)
            {
                HandleData(request);
            }

            if (FileParameters != null)
            {
                HandleFileParameters(request);
            }

            if (Cookies != null && Cookies.Count > 0)
            {
                HandleCookies(request);
            }

            return request;
        }

        protected virtual void HandlePathParameters(RestRequest request)
        {
            foreach (var pathParam in PathParameters)
            {
                request.AddParameter(pathParam.Key, pathParam.Value, ParameterType.UrlSegment);
            }
        }

        protected virtual void HandleQueryParameters(RestRequest request)
        {
            foreach (var queryParam in QueryParameters)
            {
                foreach (var value in queryParam.Value)
                {
                    request.AddQueryParameter(queryParam.Key, value);
                }
            }
        }

        protected virtual void HandleDefaultHeaders(Dictionary<string, string> defaultHeaders, RestRequest request)
        {
            foreach (KeyValuePair<string, string> headerParam in defaultHeaders)
            {
                request.AddHeader(headerParam.Key, headerParam.Value);
            }
        }

        protected virtual void HandleHeaderParameters(RestRequest request)
        {
            foreach (var headerParam in HeaderParameters)
            {
                foreach (var value in headerParam.Value)
                {
                    request.AddHeader(headerParam.Key, value);
                }
            }
        }

        protected virtual void HandleFormParameters(RestRequest request)
        {
            foreach (var formParam in FormParameters)
            {
                request.AddParameter(formParam.Key, formParam.Value);
            }
        }

        protected virtual void HandleCookies(RestRequest request)
        {
            foreach (Cookie cookie in Cookies)
            {
                request.AddCookie(cookie.Name, cookie.Value, cookie.Path, cookie.Domain);
            }
        }

        protected virtual void HandleFileParameters(RestRequest request)
        {
            foreach (var fileParam in FileParameters)
            {
                foreach (var file in fileParam.Value)
                {
                    var bytes = ClientUtils.ReadAsBytes(file);
                    var fileStream = file as FileStream;
                    if (fileStream != null)
                    {
                        request.AddFile(FileParameter.Create(fileParam.Key, bytes, System.IO.Path.GetFileName(fileStream.Name)));
                    }
                    else
                    {
                        request.AddFile(FileParameter.Create(fileParam.Key, bytes, "no_file_name_provided"));
                    }
                }
            }
        }

        protected virtual void HandleData(RestRequest request)
        {
            if (Data is Stream stream)
            {
                var contentType = "application/octet-stream";
                if (HeaderParameters != null)
                {
                    var contentTypes = HeaderParameters["Content-Type"];
                    contentType = contentTypes[0];
                }

                using (MemoryStream ms = new MemoryStream())
                {
                    stream.CopyTo(ms);
                    request.AddParameter(contentType, ms.ToArray(), ParameterType.RequestBody);
                }
            }
            else
            {
                request.RequestFormat = DataFormat.Json;
                request.AddJsonBody(Data);
            }
        }

        private RestSharp.Method ConvertMethod(HttpMethod method)
        {
            RestSharp.Method other;
            switch (method)
            {
                case HttpMethod.Get:
                    other = RestSharp.Method.Get;
                    break;
                case HttpMethod.Post:
                    other = RestSharp.Method.Post;
                    break;
                case HttpMethod.Put:
                    other = RestSharp.Method.Put;
                    break;
                case HttpMethod.Delete:
                    other = RestSharp.Method.Delete;
                    break;
                case HttpMethod.Head:
                    other = RestSharp.Method.Head;
                    break;
                case HttpMethod.Options:
                    other = RestSharp.Method.Options;
                    break;
                case HttpMethod.Patch:
                    other = RestSharp.Method.Patch;
                    break;
                default:
                    throw new ArgumentOutOfRangeException("method", method, null);
            }

            return other;
        }
    }
}
