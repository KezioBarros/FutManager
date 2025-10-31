namespace Core.Models.InputModels
{
    public class PartidaFiltroInputModel
    {
        public int? Id { get; set; }
        public int? HorarioId { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
