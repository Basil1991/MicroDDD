using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event {
    public class Event : IEvent {
        public Event() {
            Id = Guid.NewGuid().ToString();
            Time = DateTime.Now;
        }

        public DateTime Time { get; set; }
        public string Id { get; set; }
    }
}
