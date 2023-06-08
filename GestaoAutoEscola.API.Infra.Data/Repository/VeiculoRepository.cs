using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Infra.Data.Context;

namespace GestaoAutoEscola.API.Infra.Data.Repository;

public class VeiculoRepository : BaseRepository<Veiculo>, IVeiculoRepository
{
    public VeiculoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}