namespace GestaoAutoEscola.API.Domain.Entities
{
    public class CategoriaTransacao
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
    }
}
