using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Handlers {
    public interface IEventHandler {
    }

    public interface IEventHandler<TEvent> : IEventHandler where TEvent : IEvent {
        void Handle(TEvent @event);
    }
}
