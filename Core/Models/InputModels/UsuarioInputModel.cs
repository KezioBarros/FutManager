namespace Core.Models.InputModels
{
    public class UsuarioInputModel
    {
        public string Nome { get; set; }
        public string? Email { get; set; }
        public string Senha { get; set; }
        public int TipoUsuarioId { get; set; }
    }
}
