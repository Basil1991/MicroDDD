using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basil.User.Core.Model {
    public class m_Role : AggregateRoot {
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        [Required]
        [MaxLength(200)]
        public string CreateBy { get; set; }
    }
}
