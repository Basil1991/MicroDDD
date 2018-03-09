using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basil.Util.Log {
    public class ErrorHandlingMiddleware {
        private readonly RequestDelegate next;
        private readonly ILoggerFactory loggerFactory;
        public ErrorHandlingMiddleware(RequestDelegate next, ILoggerFactory logger) {
            this.next = next;
            this.loggerFactory = logger;
        }
        public async Task Invoke(HttpContext context) {
            try {
                await next(context);
            }
            catch (Exception ex) {
                var controllerName = context.Features.Get<Microsoft.AspNetCore.Routing.IRoutingFeature>().RouteData.Values["Controller"].ToString();
                var actionName = context.Features.Get<Microsoft.AspNetCore.Routing.IRoutingFeature>().RouteData.Values["Action"].ToString();
                var logger = loggerFactory.CreateLogger("Controller: " + controllerName + " Action: " + actionName);
                var message = context.Request.Path + "| " + context.Response.StatusCode;
                logger.LogError(ex, message);
            }
        }
    }

    public static class ErrorHandlingExtensions {
        public static IApplicationBuilder UseErrorHandling(this IApplicationBuilder builder) {
            return builder.UseMiddleware<ErrorHandlingMiddleware>();
        }
    }
}
