namespace Core.Models.ViewModels
{
    public class HorarioViewModel
    {
        public int id { get; set; }

        public int criado_por_usuario_id { get; set; }

        public decimal valor { get; set; }

        public int horas_contratadas { get; set; }

        public DateTime data { get; set; }
    }
}
