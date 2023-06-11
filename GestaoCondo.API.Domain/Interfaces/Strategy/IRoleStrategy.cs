using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Presentation.Dto;

namespace GestaoAutoEscola.API.Domain.Interfaces.Strategy;
public interface IRoleStrategy
{
    Usuario CriarUsuario(UsuarioDto usuario);
}