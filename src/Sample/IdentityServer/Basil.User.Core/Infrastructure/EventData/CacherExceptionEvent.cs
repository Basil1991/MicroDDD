using System;
using System.Collections.Generic;
using System.Text;
using Basil.Util.Event;

namespace Basil.User.Core.Infrastructure.EventData {
    public class CacherExceptionEvent :Event {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Message { get; set; }
        public string[] Reciever { get; set; }
    }
}
