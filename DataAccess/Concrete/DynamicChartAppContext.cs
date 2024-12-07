using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete
{
    public class DynamicChartAppContext : DbContext
    {
        private readonly string _connectionString;

        public DynamicChartAppContext(string connectionString)
        {
            _connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(_connectionString);
            }
        }
    }
}
