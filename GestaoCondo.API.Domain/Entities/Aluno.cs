namespace GestaoAutoEscola.API.Domain.Entities;

public class Aluno : Usuario
{
    public bool Aprovado { get; set; }
    public string ObjetivoAula { get; set; } = string.Empty;
    public List<Aula> Aulas { get; set; } = new List<Aula>();
    public List<Avaliacao> Avaliacoes { get; set; } = new List<Avaliacao>();
}
