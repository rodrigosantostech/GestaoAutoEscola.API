using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;

public interface ITipoVeiculoService
{
    Task<ApiResponse<TipoVeiculoDto>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<TipoVeiculoDto>>> ObterTodos();
    Task<ApiResponse<TipoVeiculoDto>> Adicionar(TipoVeiculoDto tipoVeiculo);
    Task<ApiResponse<TipoVeiculoDto>> Atualizar(TipoVeiculoDto tipoVeiculo);
    Task<ApiResponse<TipoVeiculoDto>> Deletar(int id);
}
