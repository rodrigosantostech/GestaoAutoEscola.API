using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoAutoEscola.API.Infra.Data.Repository;

public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
{
    private readonly ApplicationDbContext _dbContext;
    public VeiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }
}