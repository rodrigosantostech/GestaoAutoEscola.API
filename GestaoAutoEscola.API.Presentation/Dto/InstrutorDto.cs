namespace GestaoAutoEscola.API.Presentation.Dto;
public class InstrutorDto : UsuarioDto
{
    public string CategoriaLicenca { get; set; } = string.Empty;
    public DateTime DataValidadeLicenca { get; set; }
    public decimal Salario { get; set; }
}
