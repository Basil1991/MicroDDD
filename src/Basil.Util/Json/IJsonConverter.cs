using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Json {
    public interface IJsonConverter {
        object Deserialize(string value);
        List<TEntity> DeserializeEntities<TEntity>(string value);
        TEntity DeserializeEntitiey<TEntity>(string value);
        string Serialize(object obj);
    }
}
