using AspectCore.Injector;
using Basil.User.Core.Infrastructure.EventData;
using Basil.Util.Event;
using Basil.Util.Event.Handlers;
using Basil.Util.Messager;
using Basil.Util.Messager.GGU;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.User.Core.Infrastructure.EventHandler {
    public class CacherExceptionEventHandler : IEventHandler<CacherExceptionEvent> {
        [FromContainer]
        public IGGUMessager gGU { get; set; }
        public void Handle(CacherExceptionEvent @event) {
            GGUMessageInfo mi = new GGUMessageInfo();
            mi.Recievers = @event.Reciever;
            mi.Content = "cache error";
            gGU.Send(mi);
        }
    }
}
