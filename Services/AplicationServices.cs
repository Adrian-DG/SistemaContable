using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace API.Services
{
    public static class AplicationServices
    {
        public static IServiceCollection GetApplicationServices(this IServiceCollection services, IConfiguration  configuration)
        {
            services.GetAuthServices(configuration);
            services.GetDbServices(configuration);

            return services;
        }
    }
}