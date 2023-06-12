namespace GestaoAutoEscola.API.Presentation.Dto.Output;
public class AulaDtoOutput
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public TimeSpan HoraInicio { get; set; }
    public TimeSpan HoraFim { get; set; }
    public bool Pago { get; set; }
    public bool Finalizada { get; set; }
    public int AlunoId { get; set; }
    public int InstrutorId { get; set; }
    public int VeiculoId { get; set; }
    public int? TransacaoId { get; set; }
    public int? AvaliacaoId { get; set; }
    public UsuarioDto Instrutor { get; set; } = default!;
    public VeiculoDto Veiculo { get; set; } = default!;
    public UsuarioDto Aluno { get; set; } = default!;
}
