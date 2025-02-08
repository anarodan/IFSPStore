using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class ProdutoValidator : AbstractValidator<Produto>
    {
        public ProdutoValidator() 
        {
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("Por Favor informe o nome.")
                .NotNull().WithMessage("Por Favor informe o nome.")
                .MaximumLength(50).WithMessage("Nome pode ter no máximo 50 caracteres.");

        }
    }
}
