using ApiDevBP.Data;
using ApiDevBP.Services;
using System.Reflection;

namespace ApiDevBP
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            services.AddScoped<IGenerateJwtToken, GenerateJwtToken>();
            
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            services.AddScoped<DatabaseDbContext>();

            services.AddScoped<IUserService, UserService>();


            return services;
        }
    }
}
