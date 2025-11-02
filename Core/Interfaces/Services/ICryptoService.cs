namespace Application.Services
{
    public interface ICryptoService
    {
        string HashPassword(string senha);
        bool VerificarSenha(string senhaHash, string senhaInformada);
    }
}
