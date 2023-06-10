using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoAutoEscola.API.Infra.Data.Repository;

public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
{
    private readonly ApplicationDbContext _dbContext;
    public UsuarioRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Usuario?> ObterUsuarioPorEmail(string email)
    {
        return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Email == email);
    }
}
