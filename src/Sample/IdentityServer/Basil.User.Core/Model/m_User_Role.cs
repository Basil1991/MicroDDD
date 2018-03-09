using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Basil.User.Core.Model {
    public class m_User_Role : AggregateRoot {
        public m_User_Role() {
            this.CreateOn = DateTime.Now;
            this.CreateBy = "";
        }
        public m_User m_User { get; set; }
        public m_Role m_Role { get; set; }
        [Required]
        public DateTime CreateOn { get; set; }
        [Required]
        [MaxLength(200)]
        public string CreateBy { get; set; }
    }
}
