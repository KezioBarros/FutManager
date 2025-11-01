namespace Core.Models.InputModels
{
    public class EditarPartidaInputModel
    {
        public int Id { get; set; }
        public int HorarioId { get; set; }
        public int Tempo { get; set; }
        public int QuantidadeJogadores { get; set; }
    }
}
