using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.ApiWidgets {
    public class ApiResult : IApiResult {
        public string Message { get; set; }
        public int StatusCode { get; set; }
        public static readonly IApiResult Empty = new ApiResult {
            StatusCode = 204
        };
        public static IApiResult Succeed(string message = null) => new ApiResult {
            StatusCode = 200,
            Message = message
        };
        public static IApiResult<TResult> Succeed<TResult>(TResult result, string message = null) => new ApiResult<TResult> {
            StatusCode = 200,
            Message = message,
            Result = result
        };
        public static IApiResult Errored(string message, int? statusCode = null) => new ApiResult {
            StatusCode = statusCode ?? 400,
            Message = message
        };
        public static IApiResult<TResult> Errored<TResult>(TResult errorResult, string message, int? statusCode = null) => new ApiResult<TResult> {
            StatusCode = statusCode ?? 400,
            Message = message,
            Result = errorResult
        };
        public static IApiResult From(int statusCode, string message = null) => new ApiResult {
            StatusCode = statusCode,
            Message = message
        };
        public static IApiResult<TResult> From<TResult>(TResult result, int statusCode, string message) => new ApiResult<TResult> {
            StatusCode = statusCode,
            Message = message,
            Result = result
        };
    }
}
