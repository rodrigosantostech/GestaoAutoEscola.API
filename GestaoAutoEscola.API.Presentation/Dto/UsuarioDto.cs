namespace GestaoAutoEscola.API.Presentation.Dto;

public class UsuarioDto
{
    public UsuarioDto()
    {

    }

    public UsuarioDto(int id, string nome, string email)
    {
        Id = id;
        Nome = nome;
        Email = email;
    }

    public UsuarioDto(string email, string senha, string nome, string cpf, DateTime? dataNascimento, string? telefone, string? endereco, DateTime dataCadastro)
    {
        Email = email;
        Senha = senha;
        Nome = nome;
        Cpf = cpf;
        DataNascimento = dataNascimento;
        Telefone = telefone;
        Endereco = endereco;
        DataCadastro = dataCadastro;
    }

    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime? DataNascimento { get; set; }
    public string? Telefone { get; set; }
    public string? Endereco { get; set; }
    public DateTime DataCadastro { get; set; }
    public string? CategoriaLicenca { get; set; } = string.Empty;
    public DateTime? DataValidadeLicenca { get; set; }
    public decimal? Salario { get; set; }
    public bool? Aprovado { get; set; }
    public string? ObjetivoAula { get; set; } = string.Empty;
    public string Roles { get; set; }

    public void ForcarSenhaVazio()
    {
        Senha = string.Empty;
    }
}
