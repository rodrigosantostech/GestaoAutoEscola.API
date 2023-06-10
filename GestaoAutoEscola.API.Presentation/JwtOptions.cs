namespace GestaoCondo.API.Presentation;

public class JwtOptions
{
    public string Issuer { get; set; } = null!;

    public string Audience { get; set; } = null!;

    public string ExpiresInMinutes { get; set; } = null!;
    public string ExpiresRecoverPasswordInMinutes { get; set; } = null!;

    public string IssuerSigningKey { get; set; } = null!;
}
