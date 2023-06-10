using System.ComponentModel.DataAnnotations;

namespace GestaoAutoEscola.API.Domain.Enums;

public enum Roles
{
    [Display(Name = "ADMIN")]
    ADMIN = 1,

    [Display(Name = "GESTOR")]
    MANAGER = 2,

    [Display(Name = "ALUNO")]
    CUSTOMER = 3,

    [Display(Name = "INSTRUTOR")]
    EMPLOYEE = 4,
}
