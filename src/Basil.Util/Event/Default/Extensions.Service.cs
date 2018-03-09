using Basil.Util.Event.Handlers;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Event.Default {
    public static class Extensions {
        public static void AddEventBus(this IServiceCollection services) {
            services.AddSingleton<IEventHandlerManager, EventHandlerManager>();
            services.AddSingleton<IEventBus, EventBus>();
        }
    }
}
