using AspectCore.Injector;
using Basil.Domain.BaseModel;
using Basil.Domain.Repositories.EFCore;
using Microsoft.EntityFrameworkCore;
using Basil.Util.Cache;
using Basil.Util.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Basil.User.Repository.Repositories {
    public class UserRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<UserDbContext, TEntity, TPrimaryKey>
        where TEntity : AggregateRoot<TPrimaryKey> {
    }

    public abstract class UserRepositoryBase<TEntity> : UserRepositoryBase<TEntity, int>
        where TEntity : AggregateRoot {
    }
}