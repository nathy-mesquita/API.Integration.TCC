using MediatR;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace API.Integration.TCC.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services, IConfiguration configuration)
        {
            var assemblies = Assembly.GetExecutingAssembly();

            services.AddMediatR(assemblies);
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateStudentValidator>());
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTeacherValidator>());

            return services;
        }
    }
}
