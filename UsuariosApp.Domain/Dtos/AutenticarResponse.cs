using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Dtos
{
    /// <summary>
    /// DTO para resposta de autenticação de usuário.
    /// </summary>
    public record AutenticarResponse(
            Guid Id,                    // Identificador único do usuário
            string Nome,                // Nome do usuário
            string Email,               // Email do usuário
            string Perfil,              // Perfil do usuário
            DateTime DataHoraAcesso,    // Data e hora do acesso
            DateTime DataHoraExpiracao,  // Data e hora de expiração do token
            string Token                 // Token de autenticação
        );
}
