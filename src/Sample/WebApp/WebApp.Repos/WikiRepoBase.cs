using Basil.Domain.BaseModel;
using Basil.Domain.Repositories.EFCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Repos {
    public class WikiRepoBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<WikiDbContext, TEntity, TPrimaryKey>
         where TEntity : AggregateRoot<TPrimaryKey> {
    }

    public class WikiRepoBase<TEntity> : WikiRepoBase<TEntity, int>
     where TEntity : AggregateRoot {
    }
}
