namespace GestaoAutoEscola.API.Domain.Entities;

public class TipoTransacao
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public List<Transacao> Transacoes { get; set; } = new List<Transacao>();
}
