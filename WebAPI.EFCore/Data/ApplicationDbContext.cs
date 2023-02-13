using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using WebAPI.EFCore.Model;

namespace WebAPI.EFCore.Data
{
    /// <summary>
    /// This Method is a File/Class means DbContext collection of tables or context files.
    /// Create the Constructor method
    /// </summary>
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) 
        {

        }
        public DbSet<Category> categories { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(
                new Category
                {
                    Id = 1,
                    Name = "HTC",
                    CategoryOrder = 3
                },
                new Category
                {
                    Id = 2,
                    Name = "LG",
                    CategoryOrder = 4
                }
                );
        }
    }
}
