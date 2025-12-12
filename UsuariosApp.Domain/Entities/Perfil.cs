using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Data.Entities;

namespace UsuariosApp.Domain.Entities
{
    /// <summary>
    /// Modelo de dados para perfil.
    /// </summary>
    public class Perfil
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;

        #region Relacionamentos

        public List<Usuario>? Usuarios { get; set; }

        #endregion
    }
}
