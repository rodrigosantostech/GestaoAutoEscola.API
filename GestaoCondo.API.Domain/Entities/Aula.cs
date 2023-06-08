namespace GestaoAutoEscola.API.Domain.Entities;

public class Aula
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan Hora { get; set; }
    public string Feedback { get; set; } = string.Empty;
    public int Nota { get; set; } 
    public bool Pago { get; set; }
    public bool Finalizada { get; set; }
    public int AlunoId { get; set; } 
    public Aluno Aluno { get; set; } = new Aluno(); 
    public int InstrutorId { get; set; } 
    public Instrutor Instrutor { get; set; } = new Instrutor(); 
    public int VeiculoId { get; set; } 
    public Veiculo Veiculo { get; set; } = new Veiculo();
    public int? TransacaoId { get; set; }
    public Transacao Transacao { get; set; } = new Transacao();
    public int? AvaliacaoId { get; set; }
    public Avaliacao Avaliacao { get; set; } = new Avaliacao();
}
