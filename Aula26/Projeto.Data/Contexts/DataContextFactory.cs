using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Contexts
{
    //classe destinada somente à execução do Migrations (CodeFirst)
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        //método para executar o migrations no banco de dados
        public DataContext CreateDbContext(string[] args)
        {
        var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseSqlServer(@"Data Source=WIN10SAP;Initial Catalog=AULA27;Persist Security Info=True;User ID=SA;Password=21321");
            return new DataContext(builder.Options);
        }
    }
}