using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Infra.Data.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    /// <summary>
    /// Mapeamento da entidade Usuario
    /// </summary>
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIOS"); // Nome da tabela no banco de dados

            builder.HasKey(u => u.Id); // Chave primária

            //Configuração dos campos
            builder.Property(u => u.Id)
                .HasColumnName("ID")
                .IsRequired();

            builder.Property(u => u.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.Email)
                .HasColumnName("EMAIL")
                .HasMaxLength(100)
                .IsRequired();

            //definir o campo email como unico
            builder.HasIndex(u => u.Email)
                .IsUnique();

            builder.Property(u => u.Senha)
                .HasColumnName("SENHA")
                .HasMaxLength(100)
                .IsRequired();

            builder.Property(u => u.DataHoraCriacao)
                .HasColumnName("DATAHORACRIACAO")
                .IsRequired();

            builder.Property(u => u.PerfilId)
                 .HasColumnName("PERFIL_ID")
                 .IsRequired();

            //Mapeamento do relacionamento (1 para muitos)
            builder.HasOne(u => u.Perfil)           // Um Usuario tem um Perfil
                .WithMany(p => p.Usuarios)          // Um Perfil tem muitos Usuarios
                .HasForeignKey(u => u.PerfilId);    // Chave estrangeira
        }
    }
}
