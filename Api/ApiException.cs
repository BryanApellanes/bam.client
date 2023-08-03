using Bam.Sdk.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ApiException : Exception
    {
        public ApiException(IApiErrorResponse errorResponse): base(GetMessage(errorResponse))
        { 
            this.ApiErrorResponse = errorResponse;
        }

        public IApiErrorResponse ApiErrorResponse { get; set; }

        private static string GetMessage(IApiErrorResponse errorResponse)
        {
            StringBuilder messageBuilder = new StringBuilder();
            foreach (ErrorCause cause in errorResponse.ErrorCauses)
            {
                messageBuilder.AppendLine(cause.ErrorSummary);
            }
            return messageBuilder.ToString();
        }
    }
}
