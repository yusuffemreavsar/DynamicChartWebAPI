using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class BStoreDbContext : DbContext
    {
        public BStoreDbContext(DbContextOptions<BStoreDbContext> options)
        : base(options)
        {

        }
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<Encyclopedia> Encyclopedias { get; set; }

    }
}
