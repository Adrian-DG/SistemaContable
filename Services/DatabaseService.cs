using API.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Services
{
    public static class DatabaseService
    {
        public static IServiceCollection GetDbServices(this IServiceCollection services,IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("DevelopementConnection");
            
            services.AddDbContext<APIContext>(option => option.UseSqlite(connectionString));

            return services;
        }   
    }
}