using AspectCore.DynamicProxy;
using AspectCore.Injector;
using Basil.User.Core.Infrastructure.EventData;
using Basil.Util.Event;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basil.User.Core.Infrastructure.Interceptor {
    public class CacherInterceptor : AbstractInterceptorAttribute {
        [FromContainer]
        public IEventBus eventBus { get; set; }
        public async override Task Invoke(AspectContext context, AspectDelegate next) {
            try {
                await next(context);
            }
            catch (StackExchange.Redis.RedisException ex) {
                CacherExceptionEvent @event = new CacherExceptionEvent();
                @event.Name = "CacheException";
                @event.Type = ex.GetType().Name;
                @event.Message = ex.Message;
                @event.Reciever = new string[] { "352011" };
                eventBus.Publish<CacherExceptionEvent>(@event);
            }
            catch (Exception ex) {
                throw ex;
            }
            finally {
            }
        }
    }
}
