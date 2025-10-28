namespace Core.Models.InputModels
{
    public class HorarioFiltroInputModel
    {
        public int? Id { get; set; }
        public int? CriadoPorUsuarioId { get; set; }
        public decimal? Valor { get; set; }
        public int? HorasContratadas { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
