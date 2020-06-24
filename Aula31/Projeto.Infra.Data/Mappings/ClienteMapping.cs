using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Infra.Data.Mappings
{
    public class ClienteMapping : IEntityTypeConfiguration<ClienteEntity>
    {
        public void Configure(EntityTypeBuilder<ClienteEntity> builder)
        {
            builder.ToTable("Cliente");
            builder.HasKey(c => c.IdCliente);
            builder.Property(c => c.IdCliente)
            .HasColumnName("IdCliente");
            builder.Property(c => c.Nome)
            .HasColumnName("Nome")
            .HasMaxLength(150)
            .IsRequired();
            builder.Property(c => c.Cpf)
            .HasColumnName("Cpf")
            .HasMaxLength(11)
            .IsRequired();
            builder.Property(c => c.DataNascimento)
            .HasColumnName("DataNascimento")
            .HasColumnType("date")
            .IsRequired();
            builder.Property(c => c.IdPlano)
            .HasColumnName("IdPlano")
            .IsRequired();
            #region Relacionamentos
            builder.HasOne(c => c.Plano) //Cliente TEM 1 Plano
            .WithMany(p => p.Clientes) //Plano TEM MUITOS Clientes
            .HasForeignKey(c => c.IdPlano); //Chave estrangeira
            #endregion
        }
    }
}