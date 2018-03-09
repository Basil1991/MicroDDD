using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Basil.Domain.BaseModel;

namespace WebApp.Core.Model {
    public class m_ArticleComment : Entity {
        public m_ArticleComment() {
            this.CreateOn = DateTime.Now;
        }
        /// <summary>
        /// 评论内容
        /// </summary>
        [Required]
        [MaxLength(2000)]
        public string Content { get; set; }
        /// <summary>
        /// 评论人
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        /// <summary>
        /// 评论日期
        /// </summary>
        [Required]
        public DateTime CreateOn { get; set; }
    }
}
