using System.ComponentModel.DataAnnotations;

namespace GestaoAutoEscola.API.Domain.Enums;

public enum Roles
{
    [Display(Name = "ADMIN")]
    ADMIN = 1,

    [Display(Name = "GESTOR")]
    GESTOR = 2,

    [Display(Name = "ALUNO")]
    ALUNO = 3,

    [Display(Name = "INSTRUTOR")]
    INSTRUTOR = 4,
}
