using Microsoft.Extensions.DependencyInjection;
using ZPets.Infra.Data;

namespace ZPets.Infra
{
    public static class StartupSetup
    {
        public static IServiceCollection AddDatabaseContext(this IServiceCollection services)
        {
            services.AddDbContextPool<ApplicationContext>(options =>
            {
                options.EnableDetailedErrors();
            });

            return services;
        }
    }
}
