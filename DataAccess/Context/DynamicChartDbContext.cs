using Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Context
{
    public class DynamicChartDbContext: DbContext
    {
        public DynamicChartDbContext(DbContextOptions options) : base(options) { }
      
        public DbSet<Book> Books { get; set; }
        public DbSet<Magazine> Magazines { get; set; }
        public DbSet<StoredProcedure> StoredProcedureList { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<StoredProcedure>().HasNoKey();
        }


    }
}
