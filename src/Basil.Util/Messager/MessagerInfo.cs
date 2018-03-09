using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Messager {
    public class MessageInfo {
        public MessageInfo() {
            this.Time = DateTime.Now;
        }

        public string Content { get; set; }
        public string[] Recievers { get; set; }
        public DateTime Time { get; set; }
        public string Sender { get; set; }
    }
}
