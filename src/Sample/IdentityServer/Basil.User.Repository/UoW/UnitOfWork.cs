using AspectCore.Injector;
using Basil.Domain.BaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Basil.User.Repository.UoW {
    public class UnitOfWork : IUnitOfWork {
        public DbContext Context => _context;
        private DbContext _context;

        public UnitOfWork(DbContext dbContext) {
            this._context = dbContext;
        }

        public int Save() {
            return Context.SaveChanges();
        }

        public void Dispose() { }
    }
}
