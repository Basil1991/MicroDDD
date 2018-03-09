using System;
using System.Collections.Generic;
using System.Text;

namespace WebApp.Service.Dtos {
    public class d_Article_Add {
        public string Name { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
    }

    public class d_Article_Show {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Author { get; set; }
        public DateTime CreateOn { get; set; }
        public List<d_ArticleComment_Show> Comments { get; set; }
    }
}
