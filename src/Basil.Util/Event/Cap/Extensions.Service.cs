using Basil.Util.Event.Default;
using Basil.Util.Event.Handlers;
using Basil.Util.Event.Messages;
using DotNetCore.CAP;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Cap {
    public static class Extensions {
        public static void AddEventBus(this IServiceCollection services, Action<CapOptions> action) {
            services.AddCap(action);
            services.AddSingleton<IEventHandlerManager, EventHandlerManager>();
            services.AddScoped<IMessageEventBus, MessageEventBus>();
            services.AddScoped<IEventBus, EventBus>();
        }
    }
}
