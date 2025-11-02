using Core.Models.ViewModels;

namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        string Gerar(TokenClaimsViewModel tokenClaims);

        string? GetClaim(string claimType);
        string? GetTipoUsuarioId();
        string? GetUsuarioId();
    }
}
