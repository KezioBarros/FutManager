namespace Core.Models.ViewModels
{
    public class TokenClaimsViewModel
    {
        public TokenClaimsViewModel(int id, int tipoUsuarioId)
        {
            Id = id;
            TipoUsuarioId = tipoUsuarioId;
        }

        public int Id { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
