using Basil.Util.ApiWidgets;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Host.Controllers {
    /// <summary>
    /// 项目接口基类
    /// 1.支持路由
    /// </summary>
    [Route("webapp/[controller]/[action]")]
    [Authorize]
    public class BaseController : Controller {
        public override void OnActionExecuting(ActionExecutingContext context) {
            if (!ModelState.IsValid) {
                string errorMessage = "";
                foreach (var value in ModelState.Values) {
                    foreach (var error in value.Errors) {
                        errorMessage += error.ErrorMessage + "\r\n";
                    }
                }
                context.Result = BadRequest(errorMessage);
            }
            else {
                base.OnActionExecuting(context);
            }
        }
    }
}
