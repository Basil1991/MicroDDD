using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.ApiWidgets {
    public interface IApiResult {
        int StatusCode { get; set; }
        string Message { get; set; }
    }

    public interface IApiResult<TResult> : IApiResult {
        TResult Result { get; set; }
    }
}
