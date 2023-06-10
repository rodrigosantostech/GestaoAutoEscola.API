using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;
public interface IVeiculoService
{
    Task<ApiResponse<VeiculoDto>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<VeiculoDto>>> ObterTodos();
    Task<ApiResponse<VeiculoDto>> Adicionar(VeiculoDto veiculo);
    Task<ApiResponse<VeiculoDto>> Atualizar(VeiculoDto veiculo);
    Task<ApiResponse<VeiculoDto>> Deletar(int id);
}
