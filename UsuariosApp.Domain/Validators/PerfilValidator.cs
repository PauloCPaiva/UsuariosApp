using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Domain.Validators
{
    /// <summary>
    /// Classe para validação dos dados da entidade Perfil.
    /// </summary>
    public class PerfilValidator : AbstractValidator<Perfil>
    {
        /// <summary>
        /// Método construtor
        /// </summary>
        public PerfilValidator()
        {
            // Regras de validação do nome do perfil
            RuleFor(p => p.Nome)
                .NotEmpty().WithMessage("O nome do perfil é obrigatório.")
                .MinimumLength(4).WithMessage("O nome do perfil deve ter pelo menos 4 caracteres.");
        }
    }
}
