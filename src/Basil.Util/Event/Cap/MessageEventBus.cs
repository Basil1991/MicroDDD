using Basil.Util.Event.Messages;
using DotNetCore.CAP;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Cap {
    public class MessageEventBus : IMessageEventBus {
        private readonly ICapPublisher _publisher;

        public MessageEventBus(ICapPublisher publisher) {
            _publisher = publisher ?? throw new ArgumentNullException(nameof(publisher));
        }

        public void Publish<TEvent>(TEvent @event) where TEvent : IMessageEventData {
            _publisher.Publish(@event.Target, @event.Data, @event.Callback);
        }
    }
}
