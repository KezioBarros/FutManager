using Core.Models.ViewModels;

namespace Core.Interfaces.Services
{
    public interface ITokenService
    {
        string Gerar(TokenClaimsViewModel tokenClaims);
    }
}
