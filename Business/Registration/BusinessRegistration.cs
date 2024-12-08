using Business.Abstract;
using Business.Concrete;
using Microsoft.Extensions.DependencyInjection;

namespace Business.Registration
{
    public static class BusinessRegistration
    {
        public static void AddBusinessServices(this IServiceCollection services)
        {
            services.AddScoped<IDataBaseConnectionService, DataBaseConnectionService>();
            
        }
    }
}
