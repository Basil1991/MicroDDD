using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basil.Domain.BaseModel {
    public class UnitOfWorkInterceptor : AbstractInterceptorAttribute {
        [FromContainer]
        public IUnitOfWork uow { get; set; }


        public async override Task Invoke(AspectContext context, AspectDelegate next) {
            try {
                await next(context);
                uow.Save();
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
            }
        }
    }
}
