using Basil.Domain.BaseModel;
using Basil.Util.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using WebApp.Core.IAppService;
using WebApp.Core.Infrastructure.EventData;
using WebApp.Core.IRepos;
using WebApp.Core.Model;

namespace WebApp.Service.AppService {
    public class ArticleService : IArticleService {
        private IArticleRepo repo;
        private IUnitOfWork uow;
        private IEventBus eventBus;
        public ArticleService(IArticleRepo repo, IUnitOfWork uow, IEventBus eventBus) {
            this.repo = repo;
            this.uow = uow;
            this.eventBus = eventBus;
        }

        public void Add(m_Article article) {
            repo.Insert(article);
            uow.Save();
        }

        public void AddComment(int articleId, m_ArticleComment comment) {
            var article = repo.GetAllIncluding(a => a.Comments).Where(a => a.Id == articleId).FirstOrDefault();
            article.Comments.Add(comment);
            uow.Save();

            CommentAddedEvent commentAddedEvent = new CommentAddedEvent() {
                Article = article,
                CurrentComment = comment
            };
            eventBus.Publish(commentAddedEvent);
        }

        public void Delete(int id) {
            throw new NotImplementedException();
        }

        public m_Article Get(int id) {
            return repo.GetAllIncluding(a => a.Comments).Where(a => a.Id == id).FirstOrDefault();
        }

        public List<m_Article> GetAll() {
            return repo.GetAllIncluding(a => a.Comments).ToList();
        }

        public void Update(m_Article article) {
            throw new NotImplementedException();
        }
    }
}
