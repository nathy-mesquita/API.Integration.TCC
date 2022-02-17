using API.Integration.TCC.Domain.Repositories;
using API.Integration.TCC.Domain.Services;
using API.Integration.TCC.Infrastructure.Auth;
using API.Integration.TCC.Infrastructure.Persistence;
using API.Integration.TCC.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics.CodeAnalysis;

namespace API.Integration.TCC.Infrastructure
{
    [ExcludeFromCodeCoverage]
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            //var connectionString = configuration.GetConnectionString("IntegrationTCC");
            //Server=localhost\\SQLEXPRESS;Database=TCC;Trusted_Connection=True;
            var connection = @"Server=db;Database=master;User=sa;Password=Pa$$w0rd;";
            services.AddDbContext<IntegrationTCCDbContext>(options => options.UseSqlServer(connection));
            //services.AddDbContext<IntegrationTCCDbContext>(options => options.UseInMemoryDatabase(connectionString));

            services.AddScoped<IProjectTCCCommentsRepository, ProjectTCCCommentsRepository>();
            services.AddScoped<IProjectTCCRepository, ProjectTCCRepository>();
            services.AddScoped<IStudentRepository, StudentRepository>();
            services.AddScoped<ITeacherRepository, TeacherRepository>();

            services.AddScoped<IAuthService, AuthService>();

            return services;
        }
    }
}