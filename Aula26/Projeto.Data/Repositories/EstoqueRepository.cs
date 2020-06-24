using Microsoft.EntityFrameworkCore;
using Projeto.Data.Contexts;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Projeto.Data.Repositories
{
    public class EstoqueRepository : BaseRepository<Estoque>, IEstoqueRepository
    {
        //atributo
        private readonly DataContext dataContext;
        //construtor para injeção de dependência
        public EstoqueRepository(DataContext dataContext)
            : base(dataContext) //construtor da classe pai..
        {
            this.dataContext = dataContext;
        }
        public override List<Estoque> Consultar()
        {
            return dataContext.Estoque
            .Include(e => e.Produtos)
            .ToList();
        }
        public override List<Estoque> Consultar(Func<Estoque, bool> where)
        {
            return dataContext.Estoque
            .Include(e => e.Produtos)
            .Where(where)
            .ToList();
        }
        public override Estoque Obter(Func<Estoque, bool> where)
        {
            return dataContext.Estoque
            .Include(e => e.Produtos)
            .Where(where)
            .FirstOrDefault();
        }
        public override Estoque ObterPorId(int id)
        {
            return dataContext.Estoque
            .Include(e => e.Produtos)
            .FirstOrDefault(e => e.IdEstoque == id);
        }
    }
}