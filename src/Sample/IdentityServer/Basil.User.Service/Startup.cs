using System;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Basil.User.IdentityServer;
using AspectCore.Extensions.DependencyInjection;
using AspectCore.Injector;
using Basil.Util.Log;

namespace Basil.User.Service {
    public class Startup {
        public Startup(IHostingEnvironment env) {
            var builder = new ConfigurationBuilder()
    .SetBasePath(env.ContentRootPath);
            if (env.IsDevelopment()) {
                builder.AddJsonFile("appsettings.json");
            }
            else {
                builder.AddJsonFile("appsettings.production.json");
            }
            this.Configuration = builder.AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services) {
            services.AddUserServer(Configuration);
            services.AddMvc();
            //替换默认Di并初始化应用
            return services.InitApplication(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            else {
                app.UseErrorHandling();
            }
            app.UseMvc(routes => {
                routes.MapRoute(
                    name: "Default",
                    template: "{controller}/{action}/{id?}",
                    defaults: new { controller = "Values", action = "Get" }
                );
            });
            app.UseUserServer();
        }
    }
}
