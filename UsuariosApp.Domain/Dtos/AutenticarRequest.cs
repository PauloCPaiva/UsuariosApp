using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Dtos
{
    /// <summary>
    /// DTO para requisição de autenticação de usuário.
    /// </summary>
    public record AutenticarRequest(
            string Email,   // Email do usuário
            string Senha    // Senha do usuário
        );
}
