using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace WebCRM.Common
{
    public class ErrorResponseDto
    {
        public ErrorResponseDto() { }

        public ErrorResponseDto(HttpStatusCode statusCode, string errorMessage)
        {
            this.StatusCode = statusCode;
            this.ErrorMessage = errorMessage;
        }

        /// <summary>
        /// The http status code
        /// </summary>
        public HttpStatusCode StatusCode { get; set; }

        /// <summary>
        /// The error message to show the user
        /// </summary>
        public string ErrorMessage { get; set; } = string.Empty;
    }
}
