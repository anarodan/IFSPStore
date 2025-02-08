using FluentValidation;
using IFSPStore.Domain.Entities;


namespace IFSPStore.Service.Validators
{
    public class GrupoValidator : AbstractValidator<Grupo>
    {
        public GrupoValidator()
        {
            RuleFor(g => g.Nome)
                .NotEmpty().WithMessage("Por Favor informe o nome.")
                .NotNull().WithMessage("Por Favor informe o nome.")
                .MaximumLength(50).WithMessage("Nome pode ter no máximo 50 caracteres.");
        }
    }
}
