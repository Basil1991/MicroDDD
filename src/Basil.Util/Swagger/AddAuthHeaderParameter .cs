using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Swagger;
using Swashbuckle.AspNetCore.SwaggerGen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basil.Util.Swagger {
    public class AddAuthHeaderParameter : IOperationFilter {
        public void Apply(Operation operation, OperationFilterContext context) {
            if (operation.Parameters == null) {
                operation.Parameters = new List<IParameter>();
            }
            var actionAttrs = context.ApiDescription.ActionAttributes();
            var isAuthorized = actionAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            if (isAuthorized == false) {
                var controllerAttrs = context.ApiDescription.ControllerAttributes();
                isAuthorized = controllerAttrs.Any(a => a.GetType() == typeof(AuthorizeAttribute));
            }
            var isAllowAnonymous = actionAttrs.Any(a => a.GetType() == typeof(AllowAnonymousAttribute));
            if (isAuthorized && isAllowAnonymous == false) {
                operation.Parameters.Add(new NonBodyParameter() {
                    Name = "Authorization",
                    In = "header",
                    Type = "string",
                    Description = "Bearer Token",
                    Required = true
                });
            }
        }
    }
}
