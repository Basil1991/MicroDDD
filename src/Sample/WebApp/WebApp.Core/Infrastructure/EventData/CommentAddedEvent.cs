using Basil.Util.Event;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Core.Model;

namespace WebApp.Core.Infrastructure.EventData {
    public class CommentAddedEvent : Event {
        /// <summary>
        /// 被评论文章
        /// </summary>
        public m_Article Article { get; set; }
        /// <summary>
        /// 新增的评论
        /// </summary>
        public m_ArticleComment CurrentComment { get; set; }
    }
}
