using Basil.Domain.BaseModel;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace WebApp.Core.Model {
    public class m_Article : AggregateRoot {
        public m_Article() {
            this.CreateOn = DateTime.Now;
            this.IsEnable = true;
        }
        /// <summary>
        /// 文章名
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Name { get; set; }
        /// <summary>
        /// 文章链接
        /// </summary>
        [Required]
        [MaxLength(200)]
        public string Url { get; set; }
        /// <summary>
        /// 文章作者
        /// </summary>
        [Required]
        [MaxLength(100)]
        public string Author { get; set; }
        /// <summary>
        /// 创建日期
        /// </summary>
        [Required]
        public DateTime CreateOn { get; set; }
        /// <summary>
        /// 是否归档
        /// </summary>
        [Required]
        public bool IsEnable { get; set; }
        public List<m_ArticleComment> Comments { get; set; }
    }
}
