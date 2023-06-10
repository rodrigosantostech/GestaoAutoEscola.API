namespace GestaoAutoEscola.API.Domain.Entities;

public class TipoVeiculo
{
    public int Id { get; set; }
    public string Tipo { get; set; } = string.Empty;
    public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
}
