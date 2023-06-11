using GestaoAutoEscola.API.CrossCutting.Helper;
using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Strategy;
using GestaoAutoEscola.API.Presentation.Dto;

namespace GestaoAutoEscola.API.Services.Strategy;
public class AdminRoleStrategy : RoleStrategy
{
    public override Usuario CriarUsuario(UsuarioDto usuarioDto)
    {
        var usuario = new Usuario();

        UsuarioHelper.CriarPropriedadesComum(usuario, usuarioDto);

        return usuario;
    }

    public override Usuario AtualizarUsuario(Usuario usuario, UsuarioDto usuarioDto)
    {
        var usuarioAtualizado = new Usuario
        {
            DataCadastro = usuario.DataCadastro,
            Senha = usuario.Senha,
            Roles = usuario.Roles
        };

        UsuarioHelper.AtualizarPropriedadesComum(usuarioAtualizado, usuarioDto);

        return usuario;
    }
}