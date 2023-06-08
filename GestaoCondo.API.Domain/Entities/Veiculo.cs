namespace GestaoAutoEscola.API.Domain.Entities;

public class Veiculo
{
    public int Id { get; set; }
    public string Modelo { get; set; } = string.Empty;
    public string Marca { get; set; } = string.Empty;
    public int Ano { get; set; }
    public string Cor { get; set; } = string.Empty;
    public string Placa { get; set; } = string.Empty;
    public string Categoria { get; set; } = string.Empty;
    public bool Status { get; set; } 
    public int Kilometragem { get; set; }
    public DateTime DataUltimaManutencao { get; set; }
    public int TipoVeicuoId { get; set; }
    public List<Aula> Aulas { get; set; }  = new List<Aula>();
    public List<Instrutor> Instrutores { get; set; } = new List<Instrutor>();
    public TipoVeiculo TipoVeiculo { get; set; } = new TipoVeiculo();
}
