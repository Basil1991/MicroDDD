using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.ApiWidgets {
    public class ApiResult<TResult> : ApiResult, IApiResult<TResult> {
        public TResult Result { get; set; }
        public ApiResult() { }
        public ApiResult(TResult result, int? statusCode) {
            StatusCode = statusCode ?? 200;
            Result = result;
        }
    }
}
