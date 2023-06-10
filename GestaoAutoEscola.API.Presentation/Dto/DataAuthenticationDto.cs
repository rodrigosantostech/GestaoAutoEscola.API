namespace GestaoAutoEscola.API.Presentation.Dto;

public struct DataAuthenticationDto
{

    public DataAuthenticationDto()
    {

    }

    public string Email { get; set; } = null!;
    public string Password { get; set; } = null!;
}
