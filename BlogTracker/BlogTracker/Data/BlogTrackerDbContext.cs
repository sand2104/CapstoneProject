using Microsoft.EntityFrameworkCore;

namespace BlogTracker.Data
{
    public class BlogTrackerDbContext : DbContext
    {
        public BlogTrackerDbContext (DbContextOptions<BlogTrackerDbContext> options)
            : base(options)
        {
        }

        public DbSet<BlogTracker.Models.BlogInfo> BlogInfo { get; set; } = default!;

        public DbSet<BlogTracker.Models.EmpInfo>? EmpInfo { get; set; }
        public DbSet<BlogTracker.Models.AdminInfo> AdminInfo { get; set; }
    }
}
