using Basil.Domain.BaseModel;
using Basil.Domain.Repositories;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Basil.Domain.Repositories.MongoDb {
    public class MongoDbRepositoryBase<TEntity, TPrimaryKey> : RepositoryBase<TEntity, TPrimaryKey>
      where TEntity : AggregateRoot<TPrimaryKey> {
        public MongoDatabase Database { get { return _database; } }
        private MongoDatabase _database { get; set; }
        public virtual MongoCollection<TEntity> Collection {
            get {
                return this.Database.GetCollection<TEntity>(typeof(TEntity).Name);
            }
        }

        public MongoDbRepositoryBase(MongoDatabase database) {
            this._database = database;
        }

        public override IQueryable<TEntity> GetAll() {
            return Collection.AsQueryable();
        }

        public override TEntity Get(TPrimaryKey id) {
            var query = MongoDB.Driver.Builders.Query<TEntity>.EQ(e => e.Id, id);
            var entity = Collection.FindOne(query);
            return entity;
        }

        public override TEntity FirstOrDefault(TPrimaryKey id) {
            var query = MongoDB.Driver.Builders.Query<TEntity>.EQ(e => e.Id, id);
            return Collection.FindOne(query);
        }

        public override TEntity Insert(TEntity entity) {
            Collection.Insert(entity);
            return entity;
        }
        public override TEntity Update(TEntity entity) {
            Collection.Save(entity);
            return entity;
        }

        public override void Delete(TEntity entity) {
            Delete(entity.Id);
        }

        public override void Delete(TPrimaryKey id) {
            var query = MongoDB.Driver.Builders.Query<TEntity>.EQ(e => e.Id, id);
            Collection.Remove(query);
        }
    }
}
