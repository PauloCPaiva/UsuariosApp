using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UsuariosApp.Domain.Dtos
{
    /// <summary>
    /// DTO para a requisição de criação de conta de usuário.
    /// </summary>
    public record CriarContaRequest(
            string nome,    //Nome do usuário
            string email,   //Email do usuário
            string senha    //Senha do usuário
        );
}