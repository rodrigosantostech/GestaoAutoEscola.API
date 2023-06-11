using FluentValidation;
using GestaoAutoEscola.API.Presentation.Dto;
using GestaoAutoEscola.API.Presentation.Helper;

namespace GestaoAutoEscola.API.Presentation.Validation;
public class UsuarioDtoValidator : AbstractValidator<UsuarioDto>
{
    public UsuarioDtoValidator()
    {
        RuleFor(u => u.Email)
            .NotEmpty().WithMessage("O campo Email é obrigatório.")
            .EmailAddress().WithMessage("O campo Email deve ser um endereço de email válido.");

        RuleFor(u => u.Senha)
            .NotEmpty().WithMessage("O campo Senha é obrigatório.")
            .MinimumLength(8).WithMessage("O campo Senha deve ter no mínimo 8 caracteres.")
            .Must(senha => senha.Any(char.IsUpper)).WithMessage("A senha deve conter pelo menos uma letra maiúscula.")
            .Must(senha => senha.Any(c => !char.IsLetterOrDigit(c))).WithMessage("A senha deve conter pelo menos um caractere especial.");

        RuleFor(u => u.Cpf)
        .NotEmpty().WithMessage("O campo CPF é obrigatório.")
        .Must(CpfHelper.ValidarCpf).WithMessage("O campo CPF é inválido.");

        RuleFor(u => u.Nome)
        .NotEmpty().WithMessage("O campo Nome é obrigatório.");

        RuleFor(u => u.Telefone)
        .Cascade(CascadeMode.Stop)
        .Matches(@"^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$")
        .WithMessage("O campo Telefone deve estar no formato (99) 99999-9999.");
    }
}
