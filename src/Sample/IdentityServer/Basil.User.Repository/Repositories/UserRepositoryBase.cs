using AspectCore.Injector;
using Basil.Domain.BaseModel;
using Basil.User.Core.ICacherRepository;
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
    public class UserRepositoryBase<TEntity, TPrimaryKey> : EfCoreRepositoryBase<UserDbContext, TEntity, TPrimaryKey>, ICacherRepository<TEntity, TPrimaryKey>
        where TEntity : AggregateRoot<TPrimaryKey> {
        [FromContainer]
        public ICacher cacher { get; set; }

        [FromContainer]
        public IJsonConverter jsonConverter { get; set; }

        public List<TEntity> GetAllFromCacheAside() {
            return GetAllIncludingFromCacheAside();
        }

        public List<TEntity> GetAllIncludingFromCacheAside(params Expression<Func<TEntity, object>>[] propertySelectors) {
            string cacheKey = typeof(TEntity).Name;
            var list = cacher.ReadEntities<TEntity>(cacheKey);
            if (list == null) {
                var clientsFromRepo = GetAllIncluding(propertySelectors).ToList();
                cacher.Save(cacheKey, jsonConverter.Serialize(clientsFromRepo));
                list = clientsFromRepo;
            }
            return list;
        }
    }

    public abstract class UserRepositoryBase<TEntity> : UserRepositoryBase<TEntity, int>
        where TEntity : AggregateRoot {
    }
}