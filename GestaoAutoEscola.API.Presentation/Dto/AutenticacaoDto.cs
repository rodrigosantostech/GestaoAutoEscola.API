namespace GestaoAutoEscola.API.Presentation.Dto;

public class AutenticacaoDto
{
    public AutenticacaoDto()
    {

    }

    public AutenticacaoDto(string token, DateTime expiryDateTime)
    {
        Token = token;
        ExpiryDateTime = expiryDateTime;
    }

    public string Token { get; set; }
    public DateTime ExpiryDateTime { get; set; }
}
