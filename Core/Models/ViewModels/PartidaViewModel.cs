namespace Core.Models.ViewModels
{
    public class PartidaViewModel
    {
        public int id { get; set; }
        public int horario_id { get; set; }
        public int tempo { get; set; }

        public int quantidade_jogadores { get; set; }
        public DateTime data { get; set; }
    }
}
