namespace Core.Models.ViewModels
{
    public class AutenticacaoViewModel
    {
        public AutenticacaoViewModel(string token, TokenClaimsViewModel claim)
        {
            Token = token;
            Claim = claim;
        }

        public string Token { get; }
        TokenClaimsViewModel Claim { get; }
    }
}
