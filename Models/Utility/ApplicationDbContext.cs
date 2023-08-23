using Microsoft.EntityFrameworkCore;
using Sosyopix_CaseStudy.Models.Entity;

namespace Sosyopix_CaseStudy.Models.Utility
{
    public class ApplicationDbContext : DbContext // Inherited from DbContext class
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) // Constructor 
        {
        }

        public DbSet<Photo> Photos { get; set; } // Database Table
    }
}
