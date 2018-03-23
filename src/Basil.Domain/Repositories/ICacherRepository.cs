using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Basil.Domain.Repositories {
    //
    //Summary:
    //    Need ICacher conn
    public interface ICacherRepository<TEntity, TPrimaryKey> where TEntity : AggregateRoot<TPrimaryKey> {
        List<TEntity> GetAllFromCacheAside(string cacheKey = null);
        List<TEntity> GetAllIncludingFromCacheAside(params Expression<Func<TEntity, object>>[] propertySelectors);
        List<TEntity> GetAllIncludingFromCacheAside(string cacheKey, params Expression<Func<TEntity, object>>[] propertySelectors);
    }

    public interface ICacherRepository<TEntity> : ICacherRepository<TEntity, int> where TEntity : AggregateRoot {
    }
}
