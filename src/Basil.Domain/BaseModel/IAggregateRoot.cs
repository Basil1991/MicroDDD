using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Domain.BaseModel {


    public interface IAggregateRoot : IAggregateRoot<int>, IEntity {

    }

    public interface IAggregateRoot<TPrimaryKey> : IEntity<TPrimaryKey>, IGeneratesDomainEvents {

    }

    public interface IGeneratesDomainEvents {
        //ICollection<IEventData> DomainEvents { get; }
    }
}
