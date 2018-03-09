using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event {
    public interface IEvent {
        string Id { get; set; }

        DateTime Time { get; }
    }
}
