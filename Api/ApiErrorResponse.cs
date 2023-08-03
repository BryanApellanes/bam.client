using System;
using System.Collections.Generic;
using System.Text;

namespace Bam.Client
{
    public class ApiErrorResponse : IApiErrorResponse
    {
        public string ErrorCode { get; set; }
        public string ErrorSummary { get; set; }
        public string ErrorLink { get; set; }
        public string ErrorId { get; set; }
        public ErrorCause[] ErrorCauses { get; set; }
    }
}
