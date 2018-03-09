using Basil.Util.Messager.GGU;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using Basil.Util.Json;
using Basil.Util.Cache;
using StackExchange.Redis;
using Microsoft.Extensions.Configuration;
using Basil.Util.Event.Cap;
using Basil.Util.Event.Default;
using Microsoft.EntityFrameworkCore;
using Basil.Util.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.PlatformAbstractions;
using System.IO;
using Swashbuckle.AspNetCore.Swagger;
using Butterfly.Client.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Basil.Util.Swagger;

namespace Basil.Util {
    public static class Extensions {
        public static void AddUtils(this IServiceCollection services, IConfiguration configuration) {
            services.AddSingleton<IGGUMessager, GGUMessager>();
            services.AddSingleton<IJsonConverter, NewtonsoftJsonConverter>();
            services.AddSingleton<HttpHelp>();

            string entryAssemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
            string redisConn = configuration.GetConnectionString("Redis");
            if (!string.IsNullOrEmpty(redisConn)) {
                services.AddSingleton<ICacher, RedisCacher>(a => {
                    return new RedisCacher(a.GetService<IJsonConverter>(), redisConn);
                });
            }

            if (!string.IsNullOrEmpty(configuration["CapMQ:HostName"])) {
                services.AddEventBus(x => {
                    x.UseEntityFramework<DbContext>();
                    x.UseRabbitMQ(a => {
                        a.HostName = configuration["CapMQ:HostName"];
                        a.UserName = configuration["CapMQ:UserName"];
                        a.Password = configuration["CapMQ:Password"];
                    });
                });
            }
            else {
                services.AddEventBus();
            }

            if (!string.IsNullOrEmpty(configuration["Swagger:Version"])) {
                services.AddSwaggerGen(c => {
                    c.SwaggerDoc(configuration["Swagger:Version"],
                        new Info { Title = entryAssemblyName, Version = configuration["Swagger:Version"] });
                    var basePath = PlatformServices.Default.Application.ApplicationBasePath;
                    var xmlPath = Path.Combine(basePath, entryAssemblyName + ".xml");
                    //EF update database then entryName is "ef"
                    if (File.Exists(xmlPath)) {
                        c.IncludeXmlComments(xmlPath);
                    }
                    c.OperationFilter<AddAuthHeaderParameter>();
                });
            }

            if (!string.IsNullOrEmpty(configuration["Butterfly:CollectorUrl"])) {
                services.AddButterfly(option => {
                    option.CollectorUrl = configuration["Butterfly:CollectorUrl"];
                    option.Service = entryAssemblyName;
                });
            }

            if (!string.IsNullOrEmpty(configuration["IdentityServer4:Authentication"])) {
                services.AddAuthentication(configuration["IdentityServer4:Authentication"])
                    .AddIdentityServerAuthentication(options => {
                        options.Authority = configuration["IdentityServer4:Authority"];
                        options.RequireHttpsMetadata = false;
                        options.ApiName = configuration["IdentityServer4:ApiName"];
                    });
            }
        }
        public static void UseUtils(this IApplicationBuilder builder, IConfiguration configuration) {
            if (!string.IsNullOrEmpty(configuration["CapMQ:HostName"])) {
                builder.UseCap();
            }
            if (!string.IsNullOrEmpty(configuration["Swagger:Version"])) {
                builder.UseSwagger();
                builder.UseSwaggerUI(c => {
                    c.ShowExtensions();
                    c.EnableValidator(null);
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", System.Reflection.Assembly.GetEntryAssembly().GetName().Name + " " + configuration["Swagger:Version"]);

                });
            }
            if (!string.IsNullOrEmpty(configuration["IdentityServer4:Authentication"])) {
                builder.UseAuthentication();
            }
        }
    }
}
