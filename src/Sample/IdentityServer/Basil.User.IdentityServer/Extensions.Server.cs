using Basil.User.Core.IRepositories;
using Basil.User.Repository;
using Basil.User.EntityFrameworkCore.Repositories;
using IdentityServer4.Services;
using IdentityServer4.Stores;
using IdentityServer4.Validation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Basil.User.Core.IService;
using Basil.Domain.BaseModel;
using Basil.User.Repository.UoW;
using AspectCore.Injector;
using AspectCore.Configuration;
using Basil.Util.Event.Cap;
using Basil.User.IdentityServer.SpecialService;
using Basil.Util;
using Basil.User.Core.Infrastructure.Interceptor;
using Basil.User.Core.Infrastructure.EventHandler;
using Microsoft.AspNetCore.Builder;
using IdentityServer4.Models;
using System.Collections.Generic;
using AspectCore.Extensions.DependencyInjection;

namespace Basil.User.IdentityServer {
    public static class Extensions {
        public static void AddUserServer(this IServiceCollection services, IConfiguration configuration) {
            //仓储
            services.AddRepos(configuration);
            //拦截器注册
            addAppInterceptor(services);
            //Ids相关服务
            addIdentityServer4(services);
            //工具服务
            services.AddUtils(configuration);
        }
        private static void addIdentityServer4(IServiceCollection services) {
            services.AddTransient<IClientStore, ClientService>();
            services.AddTransient<IResourceOwnerPasswordValidator, ResourceOwnerPasswordValidator>();
            services.AddTransient<IProfileService, ProfileService>();
            services.AddIdentityServer()
                .AddDeveloperSigningCredential()
                //.AddInMemoryIdentityResources()
                .AddInMemoryApiResources(new List<ApiResource>
                    {
                            new ApiResource("api", "platform api")
                     })
                .AddProfileService<ProfileService>();
        }
        private static void addAppInterceptor(IServiceCollection services) {
            services.AddSingleton<CacherInterceptor>();
        }
        public static void UseUserServer(this IApplicationBuilder app) {
            app.UseIdentityServer();
        }
    }
}
