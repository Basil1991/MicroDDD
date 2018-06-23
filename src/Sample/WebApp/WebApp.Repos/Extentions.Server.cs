using Basil.Domain.BaseModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Core.IRepos;
using WebApp.Repos.Repos;
using Microsoft.Extensions.Configuration;
using Basil.Domain.Repositories.EFCore;

namespace WebApp.Repos {
    public static class Extentions {
        public static void AddRepos(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<WikiDbContext>(options => {
                options.UseMySql(configuration.GetConnectionString("WebAppDb"));
            });
            services.AddScoped<DbContext, WikiDbContext>();
            services.AddScoped<IUnitOfWork, EfUnitOfWork>();
            services.AddScoped<IArticleRepo, ArticleRepo>();
            services.AddScoped<UnitOfWorkInterceptor>();
        }
    }
}
