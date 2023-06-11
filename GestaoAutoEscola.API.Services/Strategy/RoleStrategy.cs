using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Presentation.Dto;

namespace GestaoAutoEscola.API.Domain.Interfaces.Strategy;
public abstract class RoleStrategy
{
    public abstract Usuario CriarUsuario(UsuarioDto usuarioDto);
    public abstract Usuario AtualizarUsuario(Usuario usuario, UsuarioDto usuarioDto);
}