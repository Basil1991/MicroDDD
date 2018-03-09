using Basil.Util.Event.Handlers;
using Basil.Util.Messager.GGU;
using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Core.Infrastructure.EventData;

namespace WebApp.Core.Infrastructure.EventHandler {
    public class CommentEventHandler : IEventHandler<CommentAddedEvent> {
        public IGGUMessager messager;
        public CommentEventHandler(IGGUMessager messager) {
            this.messager = messager;
        }
        public void Handle(CommentAddedEvent @event) {
            GGUMessageInfo info = new GGUMessageInfo() {
                Recievers = new string[] { @event.Article.Author },
                Content = @event.CurrentComment.Author + " 评论了你的文章: " + @event.CurrentComment.Content
            };
            messager.Send(info);
        }
    }
}
