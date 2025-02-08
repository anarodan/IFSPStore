using FluentValidation;
using IFSPStore.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IFSPStore.Service.Validators
{
    public class UsuarioValidator : AbstractValidator<Usuario>
    {
        public UsuarioValidator()
        {
            RuleFor(u => u.Nome)
               .NotEmpty().WithMessage("Por Favor informe o nome.")
               .NotNull().WithMessage("Por Favor informe o nome.");

            RuleFor(u => u.Login)
               .NotEmpty().WithMessage("Por Favor informe o login.")
               .NotNull().WithMessage("Por Favor informe o login.");

            RuleFor(u => u.Email)
                .EmailAddress().WithMessage("Email Inválido")
               .NotEmpty().WithMessage("Por Favor informe o email.")
               .NotNull().WithMessage("Por Favor informe o email.");

            RuleFor(u => u.Senha)
               .MinimumLength(5).WithMessage("Senha deve ter no mínimo 5 caracteres.")
               .MaximumLength(16).WithMessage("Senha deve ter no máximo 16 caracteres.")
               .NotEmpty().WithMessage("Por Favor informe a senha.")
               .NotNull().WithMessage("Por Favor informe a senha.");

        }
    }
}
