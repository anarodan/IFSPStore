using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class VendaValidator : AbstractValidator<Venda>
    {
        public VendaValidator()
        {
            RuleFor(c => c.Cliente)
                .NotEmpty().WithMessage("Por favor informe o cliente.")
                .NotNull().WithMessage("Por favor informe o cliente.");
            RuleFor(c => c.Usuario)
                .NotEmpty().WithMessage("Por favor informe o usuario.")
                .NotNull().WithMessage("Por favor informe o usuario.");
            RuleFor(c => c.Items)
                .NotEmpty().WithMessage("Por favor informe os produtos.")
                .NotNull().WithMessage("Por favor informe os produtos.");
        }
    }

    public class VendaItemValidator : AbstractValidator<VendaItem>
    {
        public VendaItemValidator()
        {
            RuleFor(v => v.Quantidade)
                .NotEmpty().WithMessage("Por Favor informe o quantidade.")
                .NotNull().WithMessage("Por Favor informe o quantidade.");

        }
    }
}
