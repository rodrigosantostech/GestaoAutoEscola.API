using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Dto.Output;
using GestaoAutoEscola.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;
public interface IAulaService
{
    Task<ApiResponse<AulaDtoOutput>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<AulaDto>>> ObterTodos();
    Task<ApiResponse<AulaDto>> Adicionar(AulaDto aula);
    Task<ApiResponse<AulaDto>> Atualizar(AulaDto aula);
    Task<ApiResponse<AulaDto>> Deletar(int id);
}
