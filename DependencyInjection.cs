using ApiDevBP.Data;
using ApiDevBP.Services;

namespace ApiDevBP
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
        
         

            services.AddScoped<DatabaseDbContext>();

            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
