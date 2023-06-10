using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;

namespace GestaoAutoEscola.API.Domain.Interfaces.Services;
public interface IAutenticacaoService
{
    Task<ApiResponse<AutenticacaoDto>> Authenticate(string email, string password);
    Task<AutenticacaoDto> UserAuthentication(Usuario userDto);
    Task<AutenticacaoDto> Revalidate(string token);
}
