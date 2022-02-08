using API.Integration.TCC.Application.Commands.CreateComment;
using API.Integration.TCC.Application.Commands.CreateProjectTCC;
using API.Integration.TCC.Application.Commands.CreateStudent;
using API.Integration.TCC.Application.Commands.CreateTeacher;
using API.Integration.TCC.Application.Commands.DeleteComment;
using API.Integration.TCC.Application.Commands.DeleteProjectTCC;
using API.Integration.TCC.Application.Commands.FinishProjectTCC;
using API.Integration.TCC.Application.Commands.StartProjectTCC;
using API.Integration.TCC.Application.Commands.UpdateComment;
using API.Integration.TCC.Application.Commands.UpdateProjectTCC;
using API.Integration.TCC.Application.Commands.UpdateTeacherAdvisor;
using FluentValidation;
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

            //services.AddAutoMapper(assemblies);
            //services.AddValidatorsFromAssembly(assemblies);
            services.AddMediatR(assemblies);

            services.AddTransient<IValidator<CreateCommentCommand>, CreateCommentValidator>();
            services.AddTransient<IValidator<CreateProjectTCCCommand>, CreateProjectTCCValidator>();
            services.AddTransient<IValidator<CreateStudentCommand>, CreateStudentValidator>();
            services.AddTransient<IValidator<CreateTeacherCommand>, CreateTeacherValidator>();
            services.AddTransient<IValidator<DeleteCommentCommand>, DeleteCommentValidator>();
            services.AddTransient<IValidator<DeleteProjectTCCCommand>, DeleteProjectTCCValidator>();
            services.AddTransient<IValidator<FinishProjectTCCCommand>, FinishProjectTCCValidator>();
            services.AddTransient<IValidator<StartProjectTCCCommand>, StartProjectTCCValidator>();
            services.AddTransient<IValidator<UpdateCommentCommand>, UpdateCommentValidator>();
            services.AddTransient<IValidator<UpdateProjectTCCCommand>, UpdateProjectTCCValidatior>();
            services.AddTransient<IValidator<UpdateTeacherAdvisorCommand>, UpdateTeacherAdvisorValidator>();


            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateStudentValidator>());
            //services.AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<CreateTeacherValidator>());


            return services;
        }
    }
}
