using System;
using System.Collections.Generic;
using System.Text;
using WebApp.Core.IRepos;
using WebApp.Core.Model;

namespace WebApp.Repos.Repos {
    public class ArticleRepo : WikiRepoBase<m_Article>,IArticleRepo {
    }
}
