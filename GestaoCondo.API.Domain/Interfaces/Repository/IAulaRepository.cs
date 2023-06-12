using GestaoAutoEscola.API.Domain.Entities;

namespace GestaoAutoEscola.API.Domain.Interfaces.Repository;

public interface IAulaRepository : IBaseRepository<Aula>
{
    new Task<Aula?> ObterPorIdAsync(int id);
    Task<IEnumerable<Aula>> ObterAulasPorVeiculo(int veiculoId);
    Task<IEnumerable<Aula>> ObterAulasPorInstrutor(int instrutorId);
}
