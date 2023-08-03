using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ApiException<T> : ApiException
    {
        public ApiException(IApiErrorResponse errorResponse, ApiResponse<T> response) : base(errorResponse)
        {
            this.ApiResponse = response;
        }

        public ApiResponse<T> ApiResponse { get; set; }
    }
}
