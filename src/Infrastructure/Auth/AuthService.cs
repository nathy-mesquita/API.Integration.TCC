using System;
using System.Text;
using System.Security.Claims;
using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.Security.Cryptography;
using API.Integration.TCC.Domain.Services;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Logging;

namespace API.Integration.TCC.Infrastructure.Auth
{
    public class AuthService : IAuthService
    {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AuthService> _logger;

        public AuthService(IConfiguration configuration, ILogger<AuthService> logger)
        {
            _configuration = configuration;
            _logger = logger;
        }

        public string ComputeSha256Hash(string password)
        {
            _logger.LogInformation("Iniciando a criação de uma senha com proteção Sha256Hash");
            byte[] bytes = SHA256.HashData(Encoding.UTF8.GetBytes(password));

            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i].ToString("x2")); //x2 faz com que seja convertido em hexadecimal
            }
            return builder.ToString();
        }

        public string GenereteJwtToken(string email, string role)
        {
            var key = _configuration["Jwt:Key"];
            var issuer = _configuration["Jwt:Issuer"];
            var audience = _configuration["Jwt:Audience"];
            _logger.LogInformation($"Pegando as chaves cadastradas no appsettings: key={key}, issuer={issuer} e audience={audience}");
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
            _logger.LogInformation($"Convertendo a chave de acesso em bytes: securirykey={securityKey}");

            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            _logger.LogInformation($"Criando as credentials para assinar o token com todas informações (algoritmos e dados do token): credentials={credentials}");

            var claims = new List<Claim>
            {
                new Claim("userName", email),
                new Claim(ClaimTypes.Role, role)
            };
            _logger.LogInformation($"Definindo as Claims, informações sobre o usuário a qual o token pertence: claims={claims}");

            var token = new JwtSecurityToken(
                                issuer: issuer, 
                                audience: audience, 
                                expires: DateTime.Now.AddHours(8),
                                signingCredentials: credentials,
                                claims: claims);
            _logger.LogInformation($"Inicializar o Token (JwtSecurityToken): Token={token}");

            var tokenHandler = new JwtSecurityTokenHandler();
            _logger.LogInformation($"Gerando a cadeira de caracteres: tokenHandler={tokenHandler}");

            var stringToken = tokenHandler.WriteToken(token);
            _logger.LogInformation($"Gerando o token em formato stringToken={stringToken}");

            return stringToken;
        }
    }
}