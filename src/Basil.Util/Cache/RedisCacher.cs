using System;
using System.Collections.Generic;
using System.Text;
using AspectCore.DynamicProxy;
using Basil.Util.Json;
using StackExchange.Redis;

namespace Basil.Util.Cache {
    public class RedisCacher : ICacher {
        IJsonConverter jsonConverter;
        ConnectionMultiplexer redis;
        IDatabase db;

        public RedisCacher(IJsonConverter jsonConverter, string conn) {
            this.jsonConverter = jsonConverter;
            this.redis = ConnectionMultiplexer.Connect(conn);
            this.db = redis.GetDatabase();
        }

        public string Read(string name) {
            return this.db.StringGet(name).ToString();
        }
        
        public List<TEntity> ReadEntities<TEntity>(string name) {
            return jsonConverter.DeserializeEntities<TEntity>(this.db.StringGet(name).ToString());
        }
        public void Save(string key, string value) {
            this.db.StringSet(key, value);
        }
        public void Remove(string key) {
            this.db.KeyDelete(key);
        }
    }
}
