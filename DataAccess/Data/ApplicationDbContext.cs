using Microsoft.EntityFrameworkCore;
using Models;

namespace OnlineStore.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Category> Category { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId=1, Name="Action", DisplayOrder=1},
                new Category { CategoryId=2, Name="SciFi", DisplayOrder=2},
                new Category { CategoryId=3, Name="Romance", DisplayOrder=3},
                new Category { CategoryId=4, Name="History", DisplayOrder=4},
                new Category { CategoryId=5, Name="War", DisplayOrder=5}
            );
        }
    }
}
