using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UsuariosApp.Domain.Entities;

namespace UsuariosApp.Infra.Data.Mappings
{
    /// <summary>
    /// Mapeamento da entidade Perfil
    /// </summary>
    public class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {
            builder.ToTable("PERFIS"); // Nome da tabela

            builder.HasKey(p => p.Id); // Chave primária

            //Configuração dos campos
            builder.Property(p => p.Id)
                .HasColumnName("ID");

            builder.Property(p => p.Nome)
                .HasColumnName("NOME")
                .HasMaxLength(25)
                .IsRequired();

            builder.HasIndex(p => p.Nome)
                .IsUnique();  //Definindo o campo como unico.
        }
    }
}
