using Microsoft.EntityFrameworkCore;
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
    }
}
