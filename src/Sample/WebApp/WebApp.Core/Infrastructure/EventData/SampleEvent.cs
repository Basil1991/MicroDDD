using Basil.Util.Event;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Core.Infrastructure.EventData {
    public class SampleEvent : Event {
        /// <summary>
        /// 只为了新建的演示字段
        /// </summary>
        public string SampleParas { get; set; }
    }
}
