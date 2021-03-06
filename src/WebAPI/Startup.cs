using API.Integration.TCC.Application;
using API.Integration.TCC.Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace API.Integration.TCC.WebAP
{
    public class Startup
    {
        private readonly IConfiguration _configuration;

        public Startup(IConfiguration configuration) => _configuration = configuration;

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddWebApi();
            services.AddApplication(_configuration);
            services.AddInfrastructure(_configuration);
            services.AddSwaggerApiDoc();
            AddJwt(services);

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            app.UseWebApi();
            if (env.IsDevelopment())
            {
                app.UseSwaggerApiDoc();
            }
        }

        public void AddJwt(IServiceCollection services)
        {
            services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme) //Schema do Token = Bearer
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true, //Se o Issuer e valido
                    ValidateAudience = true, //Se o Audience e valido
                    ValidateLifetime = true, //Se o token ja expirou 
                    ValidateIssuerSigningKey = true, //Chave de assinatura Sha256

                    IssuerSigningKey = new SymmetricSecurityKey
                    (Encoding.UTF8.GetBytes(_configuration["Jwt:key"])), //Algoritmos de seguranca
                    ValidIssuer = _configuration["Jwt:Issuer"], //Onde esta o Issuer da aplicacao
                    ValidAudience = _configuration["Jwt:Audience"] //Onde esta o Audience da aplicacao
                };
            });
        }
    }
}
