namespace GestaoAutoEscola.API.Domain.Entities;

public class Transacao
{
    public int Id { get; set; }
    public DateTime DataTransacao { get; set; }
    public decimal Valor { get; set; }
    public string Descricao { get; set; } = string.Empty;
    public int TipoTransacaoId { get; set; }
    public TipoTransacao TipoTransacao { get; set; } = new TipoTransacao();
    public int CategoriaId { get; set; }
    public CategoriaTransacao Categoria { get; set; } = new CategoriaTransacao();
    public int? AulaId { get; set; }
    public Aula Aula { get; set; } = new Aula();  


}
