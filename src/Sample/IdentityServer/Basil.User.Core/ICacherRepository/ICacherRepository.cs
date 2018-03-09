using Basil.Domain.BaseModel;
using Basil.User.Core.Infrastructure.Interceptor;
using Basil.Util.Cache;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Basil.User.Core.ICacherRepository {
    [CacherInterceptor]
    public interface ICacherRepository<TEntity, TPrimaryKey> where TEntity : AggregateRoot<TPrimaryKey> {
        List<TEntity> GetAllFromCacheAside();
        List<TEntity> GetAllIncludingFromCacheAside(params Expression<Func<TEntity, object>>[] propertySelectors);
    }

    public interface ICacherRepository<TEntity> : ICacherRepository<TEntity, int> where TEntity : AggregateRoot {
    }
}
