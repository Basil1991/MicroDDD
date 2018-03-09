using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Util.Cache {
    public interface ICacher {

        void Save(string key, string value);
        
        string Read(string name);
        
        void Remove(string key);

        List<TEntity> ReadEntities<TEntity>(string name);
    }
}
