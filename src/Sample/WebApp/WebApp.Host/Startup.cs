using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Basil.Util;
using Butterfly.Client.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.PlatformAbstractions;
using WebApp.Service;

namespace WebApp.Host {
    public class Startup {
        public Startup(IConfiguration configuration) {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            //注册WebApp中的所有服务
            services.AddWebApp(Configuration);
            services.AddMvcCore()
                .AddAuthorization()
                .AddApiExplorer()
                .AddJsonFormatters(option => {
                    option.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
                    option.ContractResolver = new Newtonsoft.Json.Serialization.DefaultContractResolver();
                    option.DateFormatString = "yyyy-MM-dd HH:mm:ss";
                });

            //替换默认Di并初始化应用
            return services.InitApplication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseUtils(Configuration);
            app.UseMvc();
        }
    }
}
