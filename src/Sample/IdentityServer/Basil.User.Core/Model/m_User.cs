using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basil.User.Core.Model {
    public partial class m_User : AggregateRoot {
        public m_User() {
            this.CreateOn = DateTime.Now;
            this.Enabled = true;
        }
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        [Required]
        [MaxLength(200)]
        public string WorkNumber { get; set; }
        [Required]
        [MaxLength(200)]
        public string Password { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        [Required]
        [MaxLength(200)]
        public string CreateBy { get; set; }
        [Required]
        public bool Enabled { get; set; }
    }
}
