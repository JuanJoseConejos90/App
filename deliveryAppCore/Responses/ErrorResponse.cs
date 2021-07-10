using System;
using System.Collections.Generic;
using System.Text;

namespace deliveryAppCore.Responses
{
    public class ErrorResponse
    {
        public string code { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public List<ErrorModel> Errors { get; set; } = new List<ErrorModel>();
    }
}
