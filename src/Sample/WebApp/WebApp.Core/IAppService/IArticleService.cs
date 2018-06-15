using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Core.Model;

namespace WebApp.Core.IAppService {
    public interface IArticleService {
        void Add(m_Article article);
        void AddComment(int articleId, m_ArticleComment comment);
        void Delete(int id);
        void Update(m_Article article);
        List<m_Article> GetAll();
        m_Article Get(int id);
        m_Article HystrixGet(int id);
    }
}
