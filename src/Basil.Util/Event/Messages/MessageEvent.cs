using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Messages {
    public class MessageEvent : Event, IMessageEventData {
        public object Data { get; set; }

        public string Target { get; set; }

        public string Callback { get; set; }
    }
}
