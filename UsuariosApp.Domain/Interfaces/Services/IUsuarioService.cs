using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Dtos;

namespace UsuariosApp.Domain.Interfaces.Services
{
    /// <summary>
    /// Interface par abstração do métodos da camda de serviço de Usuários.
    /// </summary>
    public interface IUsuarioService
    {
        /// <summary>
        /// Método para autenticação de usuário.
        /// </summary>
        AutenticarResponse Autenticar(AutenticarRequest request);

        /// <summary>
        /// Método para criação de conta de usuário.
        /// </summary>
        CriarContaResponse CriarConta(CriarContaRequest request);
    }
}
