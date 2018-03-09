using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Messages {
    public interface IMessageEventBus {
        void Publish<TEvent>(TEvent @event) where TEvent : IMessageEventData;
    }
}
