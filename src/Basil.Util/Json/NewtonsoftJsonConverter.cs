using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace Basil.Util.Json {
    public class NewtonsoftJsonConverter : IJsonConverter {
        public object Deserialize(string value) {
            return JsonConvert.DeserializeObject(value);
        }

        public List<TEntity> DeserializeEntities<TEntity>(string value) {
            return string.IsNullOrWhiteSpace(value) ? null : JsonConvert.DeserializeObject<List<TEntity>>(value);
        }

        public TEntity DeserializeEntitiey<TEntity>(string value) {
            return string.IsNullOrWhiteSpace(value) ? default(TEntity) : JsonConvert.DeserializeObject<TEntity>(value);
        }

        public string Serialize(object obj) {
            return JsonConvert.SerializeObject(obj);
        }
    }
}
