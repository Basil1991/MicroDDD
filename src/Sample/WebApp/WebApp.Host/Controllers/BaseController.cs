using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
    }
}
