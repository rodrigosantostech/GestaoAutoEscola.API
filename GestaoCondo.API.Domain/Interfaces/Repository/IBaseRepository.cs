namespace GestaoAutoEscola.API.Domain.Interfaces.Repository;

public interface IBaseRepository<TEntity> where TEntity : class
{
    Task<IEnumerable<TEntity>> ObterTodosAsync();
    Task<TEntity?> ObterPorIdAsync(int id);
    Task<TEntity> AdicionarAsync(TEntity entity);
    Task<TEntity> AtualizarAsync(TEntity entity);
    Task DeletarAsync(int id);
}
