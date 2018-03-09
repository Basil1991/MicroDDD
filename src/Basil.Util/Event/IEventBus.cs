using Basil.Util.Event.Handlers;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Basil.Util.Event {
    public interface IEventBus {
        void Publish<TEvent>(TEvent @event) where TEvent : IEvent;
    }
}
