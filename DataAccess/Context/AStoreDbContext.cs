using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class AStoreDbContext : DbContext
    {
        public AStoreDbContext(DbContextOptions<AStoreDbContext> options)
         : base(options)
        {
            
        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; } 
    }
}
