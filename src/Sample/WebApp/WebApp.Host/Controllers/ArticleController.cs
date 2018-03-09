using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Basil.Util.ApiWidgets;
using Basil.Util.Maps;
using Microsoft.AspNetCore.Mvc;
using WebApp.Core.IAppService;
using WebApp.Core.Model;
using WebApp.Service.Dtos;

namespace WebApp.Host.Controllers {
    /// <summary>
    ///  文章
    /// </summary>
    public class ArticleController : BaseController {
        private IArticleService articleService;
        public ArticleController(IArticleService articleService) {
            this.articleService = articleService;
        }
        /// <summary>
        ///  新建文章
        /// </summary>
        /// <param name="d_Article_Add">新建的文章模型</param>
        /// <returns></returns>
        [HttpPut]
        public IApiResult Add([FromBody]d_Article_Add d_Article_Add) {
            //model对象不应该传递给客户端，无论对客户端的传递和接收一律只能通过dto对象
            var m_Article = d_Article_Add.MapTo<m_Article>();
            articleService.Add(m_Article);
            return ApiResult.Succeed();
        }
        /// <summary>
        /// 新增评论
        /// 1.通知作者
        /// </summary>
        /// <param name="articleId"></param>
        /// <param name="d_ArticleComment_Add"></param>
        /// <returns></returns>
        [HttpPut("{articleId}")]
        public IApiResult AddComment(int articleId, [FromBody] d_ArticleComment_Add d_ArticleComment_Add) {
            articleService.AddComment(articleId, d_ArticleComment_Add.MapTo<m_ArticleComment>());
            return ApiResult.Succeed();
        }
        [HttpGet]
        public IApiResult<List<d_Article_Show>> GetAll() {
            return ApiResult.Succeed(articleService.GetAll().MapToList<d_Article_Show>());
        }
        [HttpGet("{Id}")]
        public IApiResult<d_Article_Show> Get(int Id) {
            return ApiResult.Succeed(articleService.Get(Id).MapTo<d_Article_Show>());
        }
    }
}