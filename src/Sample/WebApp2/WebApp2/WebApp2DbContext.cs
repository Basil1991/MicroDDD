using Microsoft.EntityFrameworkCore;

namespace WebApp2 {
    public class WebApp2DbContext : DbContext {
        public WebApp2DbContext(DbContextOptions options) : base(options) { }
    }
}
