namespace GestaoAutoEscola.API.Domain.Entities;

public class Instrutor : Usuario
{
    public string CategoriaLicenca { get; set; } = string.Empty;
    public DateTime DataValidadeLicenca { get; set; }
    public decimal Salario { get; set; }
    public List<Aula> Aulas { get; set; } = new List<Aula>(); 
    public List<Veiculo> Veiculos { get; set; } = new List<Veiculo>();
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
}