using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basil.User.Core.Model {
    public class m_ClientScopes : Entity {
        [Required]
        [MaxLength(200)]
        public string Scope { get; set; }
    }
}
