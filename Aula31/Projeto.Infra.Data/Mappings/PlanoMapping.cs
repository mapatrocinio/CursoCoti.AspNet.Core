using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Infra.Data.Mappings
{
    public class PlanoMapping : IEntityTypeConfiguration<PlanoEntity>
    {
        public void Configure(EntityTypeBuilder<PlanoEntity> builder)
        {
            //nome da tabela no BD
            builder.ToTable("Plano");
            //chave primária
            builder.HasKey(p => p.IdPlano);
            //mapear todos os campos da tabela
            builder.Property(p => p.IdPlano)
            .HasColumnName("IdPlano");
            builder.Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(150)
            .IsRequired();
            builder.Property(p => p.Descricao)
            .HasColumnName("Descricao")
            .HasMaxLength(1000)
            .IsRequired();
        }
    }
}