using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Core.Interfaces.Services;
using Core.Models.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Application.Services
{
    public class TokenService : ITokenService
    {
        private const int DURACAO_DO_TOKEN_DE_ACESSO_EM_HORAS = 4;
        private readonly JwtSecurityTokenHandler _jwtHandler = new();
        private readonly IConfiguration _configuration;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public TokenService(IConfiguration configuration, IHttpContextAccessor httpContextAccessor)
        {
            _configuration = configuration;
            _httpContextAccessor = httpContextAccessor;
        }

        public string Gerar(TokenClaimsViewModel tokenClaims)
        {
            var secretKey = _configuration.GetValue<string>("JwtSettings:SecretKey");
            var secretKeyBytes = System.Text.Encoding.UTF8.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Expires = DateTime
                    .Now.AddHours(DURACAO_DO_TOKEN_DE_ACESSO_EM_HORAS)
                    .ToUniversalTime(),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(secretKeyBytes),
                    SecurityAlgorithms.HmacSha256Signature
                ),
                Subject = new ClaimsIdentity(
                    new Claim[]
                    {
                        new("Id", tokenClaims.Id.ToString()),
                        new("TipoUsuarioId", tokenClaims.TipoUsuarioId.ToString()),
                    }
                ),
            };

            var token = _jwtHandler.CreateToken(tokenDescriptor);

            return _jwtHandler.WriteToken(token);
        }

        public string? GetClaim(string claimType)
        {
            return _httpContextAccessor.HttpContext?.User?.FindFirst(claimType)?.Value;
        }

        public string? GetTipoUsuarioId()
        {
            return GetClaim("TipoUsuarioId");
        }

        public string? GetUsuarioId()
        {
            return GetClaim("Id");
        }
    }
}
