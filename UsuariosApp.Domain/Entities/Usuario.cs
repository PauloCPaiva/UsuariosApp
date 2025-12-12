using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Entities
{
    /// <summary>
    /// Modelo de dados para usuário.
    /// </summary>
    public class Usuario
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Nome { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public DateTime DataHoraCriacao { get; set; } = DateTime.Now;
        public Guid? PerfilId { get; set; } //Chave estrangeira

        #region Relacionamentos

        public Perfil? Perfil { get; set; }

        #endregion
    }
}
