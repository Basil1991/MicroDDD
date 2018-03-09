using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basil.Util.Event;
using DotNetCore.CAP;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.Infrastructure.EventData;

namespace WebApp.Host.Controllers {
    /// <summary>
    /// 事件总线演示，实际项目中应该和业务控制器混用，这里只做演示用
    /// </summary>
    public class EventBusTestController : BaseController {
        private IEventBus eventBus;
        public EventBusTestController(IEventBus eventBus) {
            this.eventBus = eventBus;
        }
        /// <summary>
        /// 分布式事务eventBus实现，在RecMsg中设置断点，程序将执行RecMsg，得不到RecMsg的返回结果，因为执行过程是异步的
        /// </summary>
        /// <param name="publisher"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        [HttpGet("{p}")]
        public string SendMsg([FromServices]ICapPublisher publisher, string p) {
            publisher.Publish("nds.tools.user.msgtest", "message");
            return p;
        }

        /// <summary>
        /// 接收SendMsg中的信息, 实际场景是在其他服务发送消息，也可单独执行测试
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        //[CapSubscribe("nds.tools.user.msgtest")]
        //[HttpGet("{p}")]
        //public string RecMsg(string p) {
        //    return p;
        //}
        /// <summary>
        /// 测试常规EventBus，在SampleEventHandler的Handle方法中设置断点，程序将执行Handle方法
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public string Send() {
            var eventSample = new SampleEvent() {
                SampleParas = "abc"
            };
            eventBus.Publish(eventSample);
            return "OK";
        }
    }
}