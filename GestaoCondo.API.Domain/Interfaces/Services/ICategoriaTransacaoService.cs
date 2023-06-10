using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;

public interface ICategoriaTransacaoService
{
    Task<ApiResponse<CategoriaTransacaoDto>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<CategoriaTransacaoDto>>> ObterTodos();
    Task<ApiResponse<CategoriaTransacaoDto>> Adicionar(CategoriaTransacaoDto categoriaTransacao);
    Task<ApiResponse<CategoriaTransacaoDto>> Atualizar(CategoriaTransacaoDto categoriaTransacao);
    Task<ApiResponse<CategoriaTransacaoDto>> Deletar(int id);
}
