using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Mappings
{
    public class ProdutoMapping : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            //nome da tabela (opcional)
            builder.ToTable("Produto");
            //chave primária (obrigatório)
            builder.HasKey(p => p.IdProduto);
            //demais campos da entidade
            builder.Property(p => p.IdProduto)
            .HasColumnName("IdProduto");
            builder.Property(p => p.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(150)
            .IsRequired();
            builder.Property(p => p.Preco)
            .HasColumnName("Preco")
            .HasColumnType("decimal(18,2)")
            .IsRequired();
            builder.Property(p => p.Quantidade)
            .HasColumnName("Quantidade")
            .IsRequired();
            builder.Property(p => p.IdEstoque)
            .HasColumnName("IdEstoque")
            .IsRequired();
            #region Mapeamento dos Relacionamentos
            //Mapeamento de cardinalidade 1 para MUITOS
            builder.HasOne(p => p.Estoque) //Produto TEM 1 Estoque
                .WithMany(e => e.Produtos) //Estoque TEM MUITOS Produtos
                .HasForeignKey(p => p.IdEstoque); //Chave estrangeira
            #endregion
        }
    }
}