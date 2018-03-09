using Basil.Util.Event.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Core.Infrastructure.EventData;

namespace WebApp.Core.Infrastructure.EventHandler {
    public class SampleEventHandler : IEventHandler<SampleEvent> {
        public void Handle(SampleEvent @event) {
            Console.WriteLine(@event.SampleParas);
        }
    }
}
