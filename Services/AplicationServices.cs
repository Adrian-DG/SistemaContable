using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using API.Interfaces;
using API.Repositories;
using API.Data;
namespace API.Services
{
    public static class AplicationServices
    {
        public static IServiceCollection GetApplicationServices(this IServiceCollection services, IConfiguration  configuration)
        {
            services.GetAuthServices(configuration);
            services.GetDbServices(configuration);

            services.AddScoped<IAuthRepository, AuthRepository>();
            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

            return services;
        }
    }
}