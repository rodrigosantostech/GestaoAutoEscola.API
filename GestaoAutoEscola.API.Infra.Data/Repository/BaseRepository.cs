using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace GestaoAutoEscola.API.Infra.Data.Repository;

public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
{
    private readonly ApplicationDbContext _dbContext;
    private readonly DbSet<TEntity> _dbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = dbContext.Set<TEntity>();
    }

    public async Task<IEnumerable<TEntity>> ObterTodosAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<TEntity?> ObterPorIdAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public async Task<TEntity> AdicionarAsync(TEntity entity)
    {
        await _dbSet.AddAsync(entity);
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task<TEntity> AtualizarAsync(TEntity entity)
    {
        _dbContext.Entry(entity).State = EntityState.Modified;
        await _dbContext.SaveChangesAsync();
        return entity;
    }

    public async Task DeletarAsync(int id)
    {
        TEntity? entity = await _dbContext.Set<TEntity>().FindAsync(id);

        if (entity != null)
        {
            _dbContext.Set<TEntity>().Remove(entity);
            await _dbContext.SaveChangesAsync();
        }
        else
        {
            throw new ArgumentException($"Entidade com o ID {id} não encontrada");
        }
    }
}
