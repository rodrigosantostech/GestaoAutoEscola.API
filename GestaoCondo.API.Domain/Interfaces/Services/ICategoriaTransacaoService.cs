using GestaoAutoEscola.API.Presentation.Dto;
using GestaoCondo.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;

public interface ICategoriaTransacaoService
{
    Task<ApiResponse<CategoriaTransacaoDto>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<CategoriaTransacaoDto>>> ObterTodos();
    Task<ApiResponse<CategoriaTransacaoDto>> Adicionar(CategoriaTransacaoDto tipoTransacao);
    Task<ApiResponse<CategoriaTransacaoDto>> Atualizar(CategoriaTransacaoDto tipoTransacao);
    Task<ApiResponse<CategoriaTransacaoDto>> Deletar(int id);
}
