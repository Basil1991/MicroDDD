using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Handlers {
    public interface IEventHandlerManager {
        //List<IEventHandler<TEvent>> GetHandlers<TEvent>() where TEvent : IEvent;
        //void AddHandler<TEvent>(IEventHandler<TEvent> eventHandler) where TEvent : IEvent;
        List<object> GetHandlers(Type key);
        void AddHandler(Type key, object obj);
    }
}
