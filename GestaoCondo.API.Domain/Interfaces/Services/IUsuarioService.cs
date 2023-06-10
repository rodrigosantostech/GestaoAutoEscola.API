using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;
public interface IUsuarioService
{
    Task<ApiResponse<UsuarioDto>> ObterPorId(int id);
    Task<ApiResponse<IEnumerable<UsuarioDto>>> ObterTodos();
    Task<ApiResponse<UsuarioDto>> Adicionar(UsuarioDto usuario);
    Task<ApiResponse<UsuarioDto>> Atualizar(UsuarioDto usuario);
    Task<ApiResponse<UsuarioDto>> Deletar(int id);
}
