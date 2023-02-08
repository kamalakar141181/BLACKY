using Microsoft.EntityFrameworkCore;

namespace BLACKY.WebAPI.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {
        }

        public AppDbContext(DbContextOptions<AppDbContext> options)
           : base(options)
        {

        }
        public DbSet<ExpenseTypeEntity> ExpenseTypes { get; set; }
    }
}
