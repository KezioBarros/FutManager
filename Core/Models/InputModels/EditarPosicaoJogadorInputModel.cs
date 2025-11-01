namespace Core.Models.InputModels
{
    public class EditarPosicaoJogadorInputModel
    {
        public int? Id { get; set; }
        public string? Descricao { get; set; }

        public bool? PagamentoObrigatorio { get; set; }
    }
}
