using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Handlers {
    public class MessageEvent {
        public object Data { get; set; }

        public string Target { get; set; }

        public string Callback { get; set; }
    }
}
