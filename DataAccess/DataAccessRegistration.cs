using DataAccess.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
namespace DataAccess
{
     public static class DataAccessRegistration
        {
            public static void AddDataAccessServices(this IServiceCollection services,IConfiguration configuration)
            {
            services.AddDbContext<AStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("AStoreDb")));
            services.AddDbContext<BStoreDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("BStoreDb")));

        }
        }
    
}
