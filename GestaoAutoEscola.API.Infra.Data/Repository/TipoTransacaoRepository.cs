using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Infra.Data.Context;

namespace GestaoAutoEscola.API.Infra.Data.Repository;

public class TipoTransacaoRepository : BaseRepository<TipoTransacao>, ITipoTransacaoRepository
{
    public TipoTransacaoRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}

