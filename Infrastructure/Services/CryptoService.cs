using Microsoft.AspNetCore.Identity;

namespace Application.Services
{
    public class CryptoService : ICryptoService
    {
        private readonly IPasswordHasher<object> _hasher;

        public CryptoService()
        {
            _hasher = new PasswordHasher<object>();
        }

        public string HashPassword(string senha)
        {
            return _hasher.HashPassword(null, senha);
        }

        public bool VerificarSenha(string senhaHash, string senhaInformada)
        {
            var resultado = _hasher.VerifyHashedPassword(null, senhaHash, senhaInformada);
            return resultado == PasswordVerificationResult.Success
                || resultado == PasswordVerificationResult.SuccessRehashNeeded;
        }
    }
}
