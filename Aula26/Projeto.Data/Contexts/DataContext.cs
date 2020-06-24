using Microsoft.EntityFrameworkCore;
using Projeto.Data.Entities;
using Projeto.Data.Mappings;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Contexts
{
    //REGRA 1) Deverá HERDAR DbContext
    public class DataContext : DbContext
    {
        //REGRA 2) Criando um construtor para injeção de dependência
        //este construtor irá receber configurações definidas na
        //classe Startup.cs do projeto API
        public DataContext(DbContextOptions<DataContext> options)
        : base(options) //construtor da superclasse
        {
        }
        //REGRA 3) Sobrescrita (OVERRIDE) do método OnModelCreating
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //adicionar cada classe de mapeamento (Mapping) feito no projeto
            modelBuilder.ApplyConfiguration(new EstoqueMapping());
            modelBuilder.ApplyConfiguration(new ProdutoMapping());
        }
        //REGRA 4) Declarar um set/get utilizando a classe DbSet do EF
        //para cada entidade do projeto. Este DbSet irá permitir o uso
        //de expressões LAMBDA para executar consultas com qualquer
        //uma das entidades
        public DbSet<Estoque> Estoque { get; set; } //LAMBDA Functions
        public DbSet<Produto> Produto { get; set; } //LAMBDA Functions
    }
}