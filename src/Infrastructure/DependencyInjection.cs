using Microsoft.Extensions.Configuration;
using API.Integration.TCC.Domain.Services;
using API.Integration.TCC.Infrastructure.Auth;
using Microsoft.Extensions.DependencyInjection;
using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Infrastructure.Persistence.Repositories;

namespace API.Integration.TCC.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IProjectTCCCommentsRepository, ProjectTCCCommentsRepository>();
            services.AddScoped<IProjectTCCRepository, ProjectTCCRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<IAuthService, AuthService>();
            
            return services;
        }
    }
}