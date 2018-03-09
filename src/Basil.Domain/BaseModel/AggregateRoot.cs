using System;
using System.Collections.Generic;
using System.Text;

namespace Basil.Domain.BaseModel {
    public class AggregateRoot : AggregateRoot<int>, IAggregateRoot {
    }

    public class AggregateRoot<TPrimaryKey> : Entity<TPrimaryKey>, IAggregateRoot<TPrimaryKey> {
    }
}
