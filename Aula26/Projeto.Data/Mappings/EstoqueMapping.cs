using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Mappings
{
    public class EstoqueMapping : IEntityTypeConfiguration<Estoque>
    {
        public void Configure(EntityTypeBuilder<Estoque> builder)
        {
            //nome da tabela no banco de dados (opcional)
            builder.ToTable("Estoque");
            //chave primária da tabela
            //para o EF, todo campo int que for definido como chave primária
            //já é criado como identity (auto-incremento)
            builder.HasKey(e => e.IdEstoque);
            //nome do campo id do estoque (opcional)
            builder.Property(e => e.IdEstoque)
            .HasColumnName("IdEstoque");
            //campo nome do estoque
            builder.Property(e => e.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(150)
            .IsRequired();
        }
    }
}