using System;
using System.Collections.Generic;
using System.Text;

namespace deliveryAppCore.Responses
{
    public class ApiResponse<T>
    {
        public string code { get; set; }
        public bool Succeeded { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }

        public static ApiResponse<T> Fail(string errorMessage)
        {
            return new ApiResponse<T> { code = "01", Succeeded = false, Message = errorMessage };
        }
        public static ApiResponse<T> Fail(string errorMessage, T data)
        {
            return new ApiResponse<T> { code = "01", Succeeded = false, Message = errorMessage, Data = data };
        }
        public static ApiResponse<T> Success(T data)
        {
            return new ApiResponse<T> { code = "00", Succeeded = true, Message = "Success", Data = data };
        }
    }
}
