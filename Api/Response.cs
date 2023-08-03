using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;

namespace Bam.Client
{
    /// <summary>
    /// API Response
    /// </summary>
    public class Response : IResponse
    {
        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        /// <param name="rawContent">Raw content.</param>
        public Response(HttpStatusCode statusCode, Multimap<string, string> headers, string rawContent)
        {
            StatusCode = statusCode;
            Headers = headers;
            RawContent = rawContent;

            IList<string> links = new List<string>();
            headers?.TryGetValue("link", out links);
            Links = ClientUtils.Parse(links?.ToArray());
            Cookies = new List<Cookie>();
            ResponseType = typeof(object);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="headers">HTTP headers.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        public Response(HttpStatusCode statusCode, Multimap<string, string> headers) : this(statusCode, headers, string.Empty)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        /// <param name="rawContent">Raw content.</param>
        public Response(HttpStatusCode statusCode, string rawContent) : this(statusCode, new Multimap<string, string>(), rawContent)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ApiResponse{T}" /> class.
        /// </summary>
        /// <param name="statusCode">HTTP status code.</param>
        /// <param name="data">Data (parsed HTTP body)</param>
        public Response(HttpStatusCode statusCode) : this(statusCode, string.Empty)
        {
        }

        #endregion Constructors

        #region Properties

        public virtual Type ResponseType { get; protected set; }

        /// <summary>
        /// Gets or sets the status code (HTTP status code)
        /// </summary>
        /// <value>The status code.</value>
        public HttpStatusCode StatusCode { get; }

        /// <summary>
        /// Gets or sets the HTTP headers
        /// </summary>
        /// <value>HTTP headers</value>
        public Multimap<string, string> Headers { get; }

        /// <summary>
        /// Gets or sets any error text defined by the calling client.
        /// </summary>
        public string ErrorText { get; set; }

        /// <summary>
        /// Gets or sets any cookies passed along on the response.
        /// </summary>
        public List<Cookie> Cookies { get; set; }

        /// <summary>
        /// The raw content
        /// </summary>
        public string RawContent { get; }

        /// <summary>
        /// The links of this response
        /// </summary>
        public IEnumerable<WebLink> Links { get; private set; }

        #endregion Properties
    }
}
