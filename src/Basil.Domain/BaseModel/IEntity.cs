using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basil.Domain.BaseModel {
    /// <summary>
    /// A shortcut of <see cref="IEntity{TPrimaryKey}"/> for most used primary key type (<see cref="int"/>).
    /// </summary>
    public interface IEntity : IEntity<int> {

    }

    public interface IEntity<TPrimaryKey> {
        /// <summary>
        /// Unique identifier for this entity.
        /// </summary>
        [Required]
        TPrimaryKey Id { get; set; }
        /// <summary>
        /// Checks if this entity is transient (not persisted to database and it has not an <see cref="Id"/>).
        /// </summary>
        /// <returns>True, if this entity is transient</returns>
        bool IsTransient();
    }
}
