using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoAutoEscola.API.Infra.Data.Repository;

public class AulaRepository : BaseRepository<Aula>, IAulaRepository
{
    private readonly ApplicationDbContext _dbContext;
    public AulaRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
    public new async Task<Aula?> ObterPorIdAsync(int id)
    {
        return await _dbContext.Aulas.Include(x => x.Aluno)
                                     .Include(x => x.Instrutor)
                                     .Include(x => x.Veiculo)
                                     .Include(x => x.Avaliacao)
                                     .Where(a => a.Id == id)
                                     .FirstOrDefaultAsync();
    }

    public async Task<IEnumerable<Aula>> ObterAulasPorVeiculo(int veiculoId)
    {
        return await _dbContext.Aulas
                    .Where(a => a.VeiculoId == veiculoId && a.Finalizada == false)
                    .ToListAsync();
    }

    public async Task<IEnumerable<Aula>> ObterAulasPorInstrutor(int instrutorId)
    {
        return await _dbContext.Aulas
                    .Where(a => a.InstrutorId == instrutorId && a.Finalizada == false)
                    .ToListAsync();
    }
}
