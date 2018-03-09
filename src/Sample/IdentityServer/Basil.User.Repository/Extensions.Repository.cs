﻿using Basil.Domain.BaseModel;
using Basil.User.Core.IRepositories;
using Basil.User.EntityFrameworkCore.Repositories;
using Basil.User.Repository.UoW;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.User.Repository {
    public static class Extensions {
        public static void AddRepos(this IServiceCollection services, IConfiguration configuration) {
            services.AddDbContext<UserDbContext>(options => {
                options.UseMySql(configuration.GetConnectionString("UserDb"));
            });
            services.AddScoped<DbContext, UserDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddTransient<IUserRepository, UserRepository>();
            services.AddTransient<IClientRepository, ClientRepository>();

            services.AddScoped<UnitOfWorkInterceptor>();
        }
    }
}
