using Microsoft.EntityFrameworkCore;
using WebApp.Core.Model;

namespace WebApp.Repos {
    public class WikiDbContext : DbContext {
        public WikiDbContext(DbContextOptions options) : base(options) { }
        /// <summary>
        /// 文章
        /// </summary>
        public DbSet<m_Article> m_Article { get; set; }
        /// <summary>
        /// 评论
        /// </summary>
        public DbSet<m_ArticleComment> m_ArticleComment { get; set; }
    }
}
