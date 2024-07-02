using Microsoft.EntityFrameworkCore;

namespace DBProj.DB.Model
{
    public class TestDBContext : DbContext
    {
        public TestDBContext(DbContextOptions options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = true;
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Message> Messages{ get; set; }

    }
}
