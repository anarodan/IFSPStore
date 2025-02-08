using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class ClienteValidator : AbstractValidator<Cliente>
    {
        public ClienteValidator() 
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Por Favor informe o Nome.")
                .NotNull().WithMessage("Por Favor informe o Nome.")
                .MaximumLength(100).WithMessage("Nome pode ter no máximo 100 caracteres.");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("Por Favor informe o Endereço.")
                .NotNull().WithMessage("Por Favor informe o Endereço.");

            RuleFor(c => c.Bairro)
                .NotEmpty().WithMessage("Por Favor informe o Bairro.")
                .NotNull().WithMessage("Por Favor informe o Bairro.");


        }

    }
}
