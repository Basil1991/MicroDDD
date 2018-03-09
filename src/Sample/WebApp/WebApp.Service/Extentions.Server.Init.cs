using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Basil.Util.Event.Handlers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace WebApp.Service {
    public static class InitExtensions {
        public static IServiceProvider InitApplication(this IServiceCollection services, IConfiguration configuration) {
            //注册EventHandler到服务
            var types = Assembly.Load("WebApp.Core").GetExportedTypes().Where(a => a.Name.EndsWith("EventHandler")).ToList();
            addEventHandlerToServices(services, types);
            //替换默认DI
            var container = services.ToServiceContainer();
            var resolver = container.Build();
            //添加EventHandler到容器
            addEventHandlerToManager(resolver, types);
            //初始化AppSetting 配置信息
            //AppSetting.Mapping(configuration);

            return resolver;
        }

        private static void addEventHandlerToServices(IServiceCollection services, IList<Type> types) {
            foreach (var type in types) {
                services.AddSingleton(type);
            }
        }
        private static void addEventHandlerToManager(IServiceResolver resolver, IList<Type> types) {
            IEventHandlerManager Manager = resolver.GetService(typeof(IEventHandlerManager)) as IEventHandlerManager;
            foreach (var type in types) {
                var handler = (resolver.GetService(type));
                Manager.AddHandler(type.GetInterfaces().Where(a => a.GetGenericArguments().Count() > 0).FirstOrDefault().GetGenericArguments().FirstOrDefault(), handler);
            }
        }
    }
}
