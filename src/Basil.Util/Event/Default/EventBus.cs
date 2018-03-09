using Basil.Util.Event.Handlers;
using Basil.Util.Event.Messages;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Default {
    /// <summary>
    /// 事件总线
    /// </summary>
    public class EventBus : IEventBus {
        public EventBus(IEventHandlerManager manager, IMessageEventBus messageEventBus = null) {
            Manager = manager;
            MessageEventBus = messageEventBus;
        }

        public IEventHandlerManager Manager { get; set; }

        public IMessageEventBus MessageEventBus { get; set; }

        public void Publish<TEvent>(TEvent @event) where TEvent : IEvent {
            SyncHandle(@event);
            if (@event is IMessageEventData messageEvent)
                AsyncHandle(messageEvent);
        }

        private void SyncHandle<TEvent>(TEvent @event) where TEvent : IEvent {
            var handlers = Manager.GetHandlers(typeof(TEvent));
            if (handlers == null)
                return;
            foreach (var handler in handlers)
                ((IEventHandler<TEvent>)handler).Handle(@event);
        }

        private void AsyncHandle(IMessageEventData messageEvent) {
            MessageEventBus?.Publish(messageEvent);
        }
    }
}
