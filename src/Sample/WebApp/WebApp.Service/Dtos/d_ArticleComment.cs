using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Service.Dtos {
    public class d_ArticleComment_Show {
        public string Content { get; set; }
        public string Author { get; set; }
        public DateTime CreateOn { get; set; }
    }

    public class d_ArticleComment_Add {
        public string Content { get; set; }
        public string Author { get; set; }
    }
}
