using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basil.User.Core.Model {
    public class m_Client : AggregateRoot {
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        [Required]
        [MaxLength(200)]
        public string AllowedGrantTypes { get; set; }
        [Required]
        public bool Enabled { get; set; }
        public string Description { get; set; }

        public List<m_ClientScopes> m_ClientScopes { get; set; }
    }
}
