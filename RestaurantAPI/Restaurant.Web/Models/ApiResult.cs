using Microsoft.AspNetCore.Mvc;
using Restaurant.Shared.Resources;
using System.Net;
using System.Text;

namespace Restaurant.Web.Models
{
    public class ApiResult
    {
        public bool Success { get; private set; }
        public string Message { get; private set; }
        public object Data { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }

        private ApiResult(bool success, string message, object data, HttpStatusCode statusCode)
        {
            Success = success;
            Message = message;
            Data = data;
            StatusCode = statusCode;
        }
        public static ApiResult SuccessResult(object data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResult(true, GlobalResource.GenericSuccessMessage, data, statusCode);
        }

        public static ApiResult SuccessResult(string message, object data = null, HttpStatusCode statusCode = HttpStatusCode.OK)
        {
            return new ApiResult(true, message, data, statusCode);
        }

        public static ApiResult ErrorResult(object data = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            return new ApiResult(false, GlobalResource.GenericErrorMessage, data, statusCode);
        }

        public static ApiResult ErrorResult(string message, object data = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        { 
            return new ApiResult(false, message, data, statusCode);
        }

        public static ApiResult ErrorResult(IEnumerable<string> messages, object data = null, HttpStatusCode statusCode = HttpStatusCode.BadRequest)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendJoin("\r\n", messages);
            return new ApiResult(false, sb.ToString(), data, statusCode);
        }

        public static implicit operator ObjectResult(ApiResult apiResult)
        {
            return new ObjectResult(apiResult)
            {
                StatusCode = (int)apiResult.StatusCode
            };
        }
    }
}
