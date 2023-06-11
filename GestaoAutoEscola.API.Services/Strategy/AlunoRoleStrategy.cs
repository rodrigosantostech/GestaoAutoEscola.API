using GestaoAutoEscola.API.CrossCutting.Helper;
using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Strategy;
using GestaoAutoEscola.API.Presentation.Dto;

namespace GestaoAutoEscola.API.Services.Strategy;
public class AlunoRoleStrategy : RoleStrategy
{
    public override Usuario CriarUsuario(UsuarioDto usuarioDto)
    {
        var aluno = new Aluno
        {
            Aprovado = (bool)usuarioDto.Aprovado!,
            ObjetivoAula = usuarioDto.ObjetivoAula!
        };

        UsuarioHelper.CriarPropriedadesComum(aluno, usuarioDto);

        return aluno;
    }

    public override Usuario AtualizarUsuario(Usuario usuario, UsuarioDto usuarioDto)
    {
        var aluno = new Aluno
        {
            Aprovado = (bool)usuarioDto.Aprovado!,
            ObjetivoAula = usuarioDto.ObjetivoAula!,
            DataCadastro = usuario.DataCadastro,
            Senha = usuario.Senha,
            Roles = usuario.Roles
        };

        UsuarioHelper.AtualizarPropriedadesComum(aluno, usuarioDto);

        return aluno;
    }
}
