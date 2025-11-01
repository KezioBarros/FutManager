namespace Core.Models.InputModels
{
    public class PosicaoJogadorFiltroInputModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }

        public bool? PagamentoObrigatorio { get; set; }
    }
}
