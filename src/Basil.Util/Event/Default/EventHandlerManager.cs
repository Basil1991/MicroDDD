using Basil.Util.Event.Handlers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace Basil.Util.Event.Default {
    public class EventHandlerManager : IEventHandlerManager {
        public void AddHandler(Type key, object obj) {
            EventHandlerContainer.Add(key, obj);
        }

        public List<object> GetHandlers(Type key) {
            return EventHandlerContainer.GetAll().Where(a => a.Key == key).Select(a => a.Value).ToList();
        }

        //public List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent {
        //    return EventHandlerContainer<IEventHandler<TEvent>>.GetAll();
        //}

        //public void AddHandler<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent {
        //    EventHandlerContainer<IEventHandler<TEvent>>.Add(eventHandler);
        //}
    }
}
