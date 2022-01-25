using Microsoft.Extensions.Configuration;
using API.Integration.TCC.Domain.Services;
using API.Integration.TCC.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;

namespace API.Integration.TCC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // services.AddScoped<IProjectRepository, ProjectRepository>();
            // services.AddScoped<ISkillRepository, SkillRepository>();
            // services.AddScoped<IUserRepository, UserRepository>();
            // services.AddScoped<IUserSkillRepository, UserSkillRepository>();

            services.AddScoped<IAuthService, AuthService>();
            
            return services;
        }
    }
}