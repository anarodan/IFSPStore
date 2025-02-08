

using FluentValidation;
using IFSPStore.Domain.Entities;

namespace IFSPStore.Service.Validators
{
    public class CidadeValidator : AbstractValidator<Cidade>
    {
        public CidadeValidator() 
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por Favor informe o Nome.")
                .NotNull().WithMessage("Por Favor informe o Nome.")
                .MaximumLength(50).WithMessage("Nome pode ter no máximo 50 caracteres.");
               
            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("Por Favor informe o Estado.")
                .NotNull().WithMessage("Por Favor informe o Estado.");
        }
    }
}
