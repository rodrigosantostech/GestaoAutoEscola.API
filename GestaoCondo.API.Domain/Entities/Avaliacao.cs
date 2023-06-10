namespace GestaoAutoEscola.API.Domain.Entities;

public class Avaliacao
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public int Nota { get; set; }
    public string Feedback { get; set; } = string.Empty;

    public int InstrutorId { get; set; }
    public Instrutor Instrutor { get; set; } = default!;

    public int AulaId { get; set; }
    public Aula Aula { get; set; } = default!;

    public int AlunoId { get; set; }
    public Aluno Aluno { get; set; } = default!; 

}
