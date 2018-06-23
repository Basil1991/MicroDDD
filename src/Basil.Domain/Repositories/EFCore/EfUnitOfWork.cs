using Basil.Domain.BaseModel;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Domain.Repositories.EFCore
{
    public class EfUnitOfWork : IUnitOfWork{
        public DbContext Context { get; }

        public EfUnitOfWork(DbContext dbContext){
            this.Context = dbContext;
        }


        public int Save(){
            return Context.SaveChanges();
        }

        public void Dispose() { }
    }
}
