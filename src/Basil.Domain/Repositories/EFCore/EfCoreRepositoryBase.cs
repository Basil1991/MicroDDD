﻿using AspectCore.Injector;
using Basil.Domain.BaseModel;
using Basil.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Basil.Domain.Repositories.EFCore {
    public class EfCoreRepositoryBase<TDbContext, TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
        where TEntity : AggregateRoot<TPrimaryKey>
        where TDbContext : DbContext {

        [FromContainer]
        public DbContext Context { get; set; }

        public DbSet<TEntity> Table => Context.Set<TEntity>();

        public override IQueryable<TEntity> GetAll() {
            return GetAllIncluding();
        }

        public override IQueryable<TEntity> GetAllIncluding(params Expression<Func<TEntity, object>>[] propertySelectors) {
            var query = Table.AsQueryable();

            if (propertySelectors != null && propertySelectors.Count() > 0) {
                foreach (var propertySelector in propertySelectors) {
                    query = query.Include(propertySelector);
                }
            }

            return query;
        }

        public override async Task<List<TEntity>> GetAllListAsync() {
            return await GetAll().ToListAsync();
        }

        public override async Task<List<TEntity>> GetAllListAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GetAll().Where(predicate).ToListAsync();
        }

        public override async Task<TEntity> SingleAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GetAll().SingleAsync(predicate);
        }

        public override async Task<TEntity> FirstOrDefaultAsync(TPrimaryKey id) {
            return await GetAll().FirstOrDefaultAsync(CreateEqualityExpressionForId(id));
        }

        public override async Task<TEntity> FirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GetAll().FirstOrDefaultAsync(predicate);
        }

        public override TEntity Insert(TEntity entity) {
            return Table.Add(entity).Entity;
        }

        public override Task<TEntity> InsertAsync(TEntity entity) {
            return Task.FromResult(Insert(entity));
        }

        public override TPrimaryKey InsertAndGetId(TEntity entity) {
            entity = Insert(entity);

            if (entity.IsTransient()) {
                Context.SaveChanges();
            }

            return entity.Id;
        }

        public override async Task<TPrimaryKey> InsertAndGetIdAsync(TEntity entity) {
            entity = await InsertAsync(entity);

            if (entity.IsTransient()) {
                await Context.SaveChangesAsync();
            }

            return entity.Id;
        }

        public override TPrimaryKey InsertOrUpdateAndGetId(TEntity entity) {
            entity = InsertOrUpdate(entity);

            if (entity.IsTransient()) {
                Context.SaveChanges();
            }

            return entity.Id;
        }

        public override async Task<TPrimaryKey> InsertOrUpdateAndGetIdAsync(TEntity entity) {
            entity = await InsertOrUpdateAsync(entity);

            if (entity.IsTransient()) {
                await Context.SaveChangesAsync();
            }

            return entity.Id;
        }

        public override TEntity Update(TEntity entity) {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return entity;
        }

        public override Task<TEntity> UpdateAsync(TEntity entity) {
            AttachIfNot(entity);
            Context.Entry(entity).State = EntityState.Modified;
            return Task.FromResult(entity);
        }

        public override void Delete(TEntity entity) {
            AttachIfNot(entity);
            Table.Remove(entity);
        }

        public override void Delete(TPrimaryKey id) {
            var entity = GetFromChangeTrackerOrNull(id);
            if (entity != null) {
                Delete(entity);
                return;
            }

            entity = FirstOrDefault(id);
            if (entity != null) {
                Delete(entity);
                return;
            }

            //Could not found the entity, do nothing.
        }

        public override async Task<int> CountAsync() {
            return await GetAll().CountAsync();
        }

        public override async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GetAll().Where(predicate).CountAsync();
        }

        public override async Task<long> LongCountAsync() {
            return await GetAll().LongCountAsync();
        }

        public override async Task<long> LongCountAsync(Expression<Func<TEntity, bool>> predicate) {
            return await GetAll().Where(predicate).LongCountAsync();
        }

        protected virtual void AttachIfNot(TEntity entity) {
            var entry = Context.ChangeTracker.Entries().FirstOrDefault(ent => ent.Entity == entity);
            if (entry != null) {
                return;
            }

            Table.Attach(entity);
        }

        public DbContext GetDbContext() {
            return Context;
        }

        //public Task EnsureCollectionLoadedAsync<TProperty>(
        //    TEntity entity,
        //    Expression<Func<TEntity, IEnumerable<TProperty>>> collectionExpression,
        //    CancellationToken cancellationToken)
        //    where TProperty : class {
        //    return Context.Entry(entity).Collection(collectionExpression).LoadAsync(cancellationToken);
        //}

        //public Task EnsurePropertyLoadedAsync<TProperty>(
        //    TEntity entity,
        //    Expression<Func<TEntity, TProperty>> propertyExpression,
        //    CancellationToken cancellationToken)
        //    where TProperty : class {
        //    return Context.Entry(entity).Reference(propertyExpression).LoadAsync(cancellationToken);
        //}

        private TEntity GetFromChangeTrackerOrNull(TPrimaryKey id) {
            var entry = Context.ChangeTracker.Entries()
                .FirstOrDefault(
                    ent =>
                        ent.Entity is TEntity &&
                        EqualityComparer<TPrimaryKey>.Default.Equals(id, (ent.Entity as TEntity).Id)
                );

            return entry?.Entity as TEntity;
        }
    }

}
