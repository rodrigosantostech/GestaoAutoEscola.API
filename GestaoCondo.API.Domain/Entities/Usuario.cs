using System.Security.Claims;

namespace GestaoAutoEscola.API.Domain.Entities;
public class Usuario
{
    public int Id { get; set; }
    public string Email { get; set; } = string.Empty;
    public string Senha { get; set; } = string.Empty;
    public string Nome { get; set; } = string.Empty;
    public string Cpf { get; set; } = string.Empty;
    public DateTime? DataNascimento { get; set; }
    public string? Telefone { get; set; }
    public string? Endereco { get; set; }
    public DateTime DataCadastro { get; set; }
    public string? Roles { get; set; }

    public IList<Claim> GetClaims()
    {
        IList<Claim> claims = new List<Claim>
        {
            new Claim("ID", Id.ToString()),
            new Claim("EMAIL", Email),
            new Claim("NOME", Nome)
        };
        return claims;
    }

    public IList<Claim>? GetRoles()
    {
        if (string.IsNullOrEmpty(Roles)) return null;
        string[] roles = Roles?.Split(',') ?? new string[] { };
        IList<Claim> claims = new List<Claim>();
        foreach (string rule in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, rule.Trim()));
        }
        return claims;
    }
}
