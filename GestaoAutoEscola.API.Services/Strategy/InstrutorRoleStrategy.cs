using GestaoAutoEscola.API.CrossCutting.Helper;
using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Strategy;
using GestaoAutoEscola.API.Presentation.Dto;

namespace GestaoAutoEscola.API.Services.Strategy;
public class InstrutorRoleStrategy : RoleStrategy
{
    public override Usuario CriarUsuario(UsuarioDto usuario)
    {
        var instrutor = new Instrutor
        {
            CategoriaLicenca = usuario.CategoriaLicenca!,
            DataValidadeLicenca = (DateTime)usuario.DataValidadeLicenca!,
            Salario = (decimal)usuario.Salario!
        };

        // Configurar as propriedades comuns entre os usuários
        UsuarioHelper.CriarPropriedadesComum(instrutor, usuario);

        return instrutor;
    }

    public override Usuario AtualizarUsuario(Usuario usuario, UsuarioDto usuarioDto)
    {
        var instrutor = new Instrutor
        {
            CategoriaLicenca = usuarioDto.CategoriaLicenca!,
            DataValidadeLicenca = (DateTime)usuarioDto.DataValidadeLicenca!,
            Salario = (decimal)usuarioDto.Salario!,
            DataCadastro = usuario.DataCadastro,
            Senha = usuario.Senha,
            Roles = usuario.Roles
        };

        UsuarioHelper.AtualizarPropriedadesComum(instrutor, usuarioDto);

        return instrutor;
    }

}
