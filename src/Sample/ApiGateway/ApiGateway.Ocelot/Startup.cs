using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basil.Util;
using Butterfly.Client.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

namespace ApiGateway.Ocelot {
    public class Startup {
        public Startup(IHostingEnvironment environment) {
            var builder = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath);
            if (environment.IsDevelopment()) {
                builder.AddJsonFile("appsettings.json");
            }
            else {
                builder.AddJsonFile("appsettings.production.json");
            }
            builder.AddJsonFile("configuration.json", optional: false, reloadOnChange: true);
            this.Configuration = builder.AddEnvironmentVariables().Build();
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services) {
            services.AddOcelot(Configuration);
            services.AddUtils(Configuration);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public async void Configure(IApplicationBuilder app, IHostingEnvironment env) {
            if (env.IsDevelopment()) {
                app.UseDeveloperExceptionPage();
            }
            app.UseUtils(Configuration);
            await app.UseOcelot();
        }
    }
}
