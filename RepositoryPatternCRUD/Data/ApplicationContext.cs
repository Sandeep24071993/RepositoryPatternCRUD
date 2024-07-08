using Microsoft.EntityFrameworkCore;
using RepositoryPatternCRUD.Models;
namespace RepositoryPatternCRUD.Data
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base (options)
        {
                
        }
        public DbSet<User> Users { get; set; }
    }
}
