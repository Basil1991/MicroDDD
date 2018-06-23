using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Basil.User.Core.Model;
using Basil.User.Core.Infrastructure.AppSetting;

namespace Basil.User.Repository {
    public class UserDbContext : DbContext {
        public UserDbContext(DbContextOptions options) :
            base(options) { }
        public DbSet<m_User> m_User { get; set; }
        public DbSet<m_Client> m_Client { get; set; }
        public DbSet<m_Role> m_Role { get; set; }
        public DbSet<m_User_Role> m_User_Role { get; set; }
        public DbSet<m_ClientScopes> m_ClientScopes { get; set; }
    }
}
