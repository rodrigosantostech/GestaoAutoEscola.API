using GestaoAutoEscola.API.Domain.Entities;
using GestaoAutoEscola.API.Domain.Interfaces.Repository;
using GestaoAutoEscola.API.Domain.Interfaces.Services;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Response;
using GestaoCondo.API.Presentation;
using Mapster;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace GestaoAutoEscola.API.Services.Services;

public class AutenticacaoService : IAutenticacaoService
{

    private readonly JwtOptions _jwtOptions;
    private readonly IUsuarioRepository _usuarioRepository;

    public AutenticacaoService(JwtOptions jwtOptions, IUsuarioRepository usuarioRepository)
    {
        _jwtOptions = jwtOptions ?? throw new ArgumentNullException(nameof(jwtOptions));
        _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
    }

    public async Task<ApiResponse<AutenticacaoDto>> Authenticate(string email, string senha)
    {
        try
        {
            var user = await _usuarioRepository.ObterUsuarioPorEmail(email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(senha, user.Senha)) return new ApiResponse<AutenticacaoDto>(false, null!, "invalid user");
            var auth = await UserAuthentication(user);
            return new ApiResponse<AutenticacaoDto>(true, auth);
        }
        catch (Exception ex)
        {
            return new ApiResponse<AutenticacaoDto>(false, null!, ex, "Error authenticate user.");
        }
    }

    public async Task<AutenticacaoDto> UserAuthentication(Usuario user)
    {
        var authentication = GenerateUserToken(user, _jwtOptions.ExpiresInMinutes);
        return await Task.FromResult(authentication);
    }

    private AutenticacaoDto GenerateUserToken(Usuario user, string expiresInMinutes)
    {
        var now = DateTime.Now;
        var expiresDate = now.AddMinutes(double.Parse(expiresInMinutes));
        IList<Claim> claims = user.GetClaims();

        var roles = user.GetRoles();
        if (roles != null)
            foreach (var role in roles)
                claims.Add(role);

        var token = new JwtSecurityToken(
            issuer: _jwtOptions.Issuer,
            audience: _jwtOptions.Audience,
            notBefore: now,
            claims: claims,
            expires: expiresDate,
            signingCredentials: new SigningCredentials(
                new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_jwtOptions.IssuerSigningKey)),
                    SecurityAlgorithms.HmacSha256)
            );
        var generatedToken = new JwtSecurityTokenHandler().WriteToken(token);
        return new AutenticacaoDto(generatedToken, expiresDate);
    }

    public async Task<AutenticacaoDto> Revalidate(string token)
    {
        var userValid = await Verify(token);
        if (userValid != null)
        {
            return await UserAuthentication(userValid.Adapt<Usuario>());
        }
        throw new UnauthorizedAccessException("Invalid token");
    }

    private async Task<UsuarioDto> Verify(string token)
    {
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.IssuerSigningKey));
        var validator = new JwtSecurityTokenHandler();

        var validationParameters = new TokenValidationParameters()
        {
            IssuerSigningKey = key,
            ValidIssuer = _jwtOptions.Issuer,
            ValidAudience = _jwtOptions.Audience,
            ValidateIssuerSigningKey = true,
            ValidateAudience = true,
            ValidateLifetime = false
        };
        try
        {
            if (validator.CanReadToken(token))
            {
                ClaimsPrincipal principal;
                principal = validator.ValidateToken(token, validationParameters, out SecurityToken validatedToken);

                if (principal.HasClaim(c => c.Type == "ID") && principal.HasClaim(c => c.Type == "NAME") && principal.HasClaim(c => c.Type == "EMAIL"))
                {
                    var id = principal.Claims.FirstOrDefault(c => c.Type == "ID")?.Value;
                    var name = principal.Claims.FirstOrDefault(c => c.Type == "NAME")?.Value;
                    var email = principal.Claims.FirstOrDefault(c => c.Type == "EMAIL")?.Value;
                    if (id != null && name != null && email != null)
                        return await Task.FromResult(new UsuarioDto(int.Parse(id), name, email));
                }
            }
            throw new UnauthorizedAccessException("Invalid token");
        }
        catch (SecurityTokenException)
        {
            throw new UnauthorizedAccessException("Invalid token");
        }
    }
}
