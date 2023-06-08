using GestaoCondo.API.Presentation.Dto;
using GestaoCondo.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;

public interface ITipoTransacaoService
{
    Task<ApiResponse<TipoTransacaoDto>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<TipoTransacaoDto>>> ObterTodos();
    Task<ApiResponse<TipoTransacaoDto>> Adicionar(TipoTransacaoDto tipoTransacao);
    Task<ApiResponse<TipoTransacaoDto>> Atualizar(TipoTransacaoDto tipoTransacao);
    Task<ApiResponse<TipoTransacaoDto>> Deletar(int id);
}
