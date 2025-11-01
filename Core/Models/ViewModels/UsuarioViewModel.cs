namespace Core.Models.ViewModels
{
    public class UsuarioViewModel
    {
        public int id { get; set; }
        public string nome { get; set; }
        public string? email { get; set; }
        public string? senha { get; set; }
        public int tipo_usuario_id { get; set; }
    }
}
