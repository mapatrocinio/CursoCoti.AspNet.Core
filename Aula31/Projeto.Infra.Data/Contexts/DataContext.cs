using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Infra.Data.Contexts
{
    //REGRA 1) HERDAR DbContext!
    public class DataContext : DbContext
    {
        //REGRA 2) Construtor para receber a connectionstring e envia-la
        //para o construtor da superclasse -> DbContext (Injeção de dependência)
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) //construtor da superclasse (DbContext)
        {
        }
        //REGRA 3) Sobrescrever o método OnModelCreating (OVERRIDE)
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new PlanoMapping());
            modelBuilder.ApplyConfiguration(new ClienteMapping());
        }
        //REGRA 4) Declarar um DbSet para cada classe de entidade (LAMBDA)
        public DbSet<PlanoEntity> Plano { get; set; }
        public DbSet<ClienteEntity> Cliente { get; set; }
    }
}