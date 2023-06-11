using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Presentation.Dto;

namespace GestaoAutoEscola.API.CrossCutting.Helper;
public class UsuarioHelper
{
    public static void CriarPropriedadesComum(Usuario usuario, UsuarioDto usuarioDto)
    {
        usuario.Email = usuarioDto.Email;
        usuario.Cpf = usuarioDto.Cpf;
        usuario.Senha = BCrypt.Net.BCrypt.HashPassword(usuarioDto.Senha);
        usuario.DataCadastro = DateTime.Now;
        usuario.Telefone = usuarioDto.Telefone;
        usuario.Nome = usuarioDto.Nome;
        usuario.DataNascimento = usuarioDto.DataNascimento;
        usuario.Endereco = usuarioDto.Endereco;
        usuario.Roles = usuarioDto.Roles;
    }

    public static void AtualizarPropriedadesComum(Usuario usuario, UsuarioDto usuarioDto)
    {
        usuario.Email = usuarioDto.Email;
        usuario.Cpf = usuarioDto.Cpf;
        usuario.Telefone = usuarioDto.Telefone;
        usuario.Nome = usuarioDto.Nome;
        usuario.DataNascimento = usuarioDto.DataNascimento;
        usuario.Endereco = usuarioDto.Endereco;
    }
}
