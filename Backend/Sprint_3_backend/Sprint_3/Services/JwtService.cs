using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Configuration;
using System;

namespace Sprint_3.Services
{
    public class JwtService
    {
        private readonly IConfiguration _config;

        public JwtService(IConfiguration config)
        {
            _config = config;
        }

        // ALTERADO: Agora aceita explicitamente 2 argumentos: login e role
        public string GerarToken(string login, string role)
        {
            var keyStr = _config["Jwt:Key"] ?? throw new Exception("Chave JWT não configurada no appsettings.json");
            var keyBytes = Encoding.UTF8.GetBytes(keyStr);

            var claims = new[]
            {
                new Claim(ClaimTypes.Name, login),
                new Claim(ClaimTypes.Role, role ?? "User")
            };

            var token = new JwtSecurityToken(
                issuer: _config["Jwt:Issuer"],
                audience: _config["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(2),
                signingCredentials: new SigningCredentials(
                    new SymmetricSecurityKey(keyBytes),
                    SecurityAlgorithms.HmacSha256
                )
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}