using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebApp.Repos;
using System;
using Basil.Util;
using WebApp.Core.IAppService;
using WebApp.Service.AppService;

namespace WebApp.Service {
    public static class Extentions {
        public static void AddWebApp(this IServiceCollection services, IConfiguration configuration) {
            //注册仓储服务
            services.AddRepos(configuration);
            //注册工具服务
            services.AddUtils(configuration);
            //应用服务
            addAppService(services);
        }

        private static void addAppService(IServiceCollection services) {
            services.AddScoped<IArticleService, ArticleService>();
        }
    }
}
