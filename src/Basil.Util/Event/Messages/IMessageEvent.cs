using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Messages {
    public interface IMessageEventData : IEvent {
        object Data { get; set; }

        string Target { get; set; }

        string Callback { get; set; }
    }
}
