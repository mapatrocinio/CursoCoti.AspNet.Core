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
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        private readonly DataContext dataContext;
        public ProdutoRepository(DataContext dataContext)
        : base(dataContext)
        {
            this.dataContext = dataContext;
        }
        //sobrescrita de método (OVERRIDE)
        public override List<Produto> Consultar()
        {
            //retornar uma consulta de Produtos
            //fazendo JOIN com a entidade Estoque
            return dataContext.Produto
            .Include(p => p.Estoque) //JOIN..
            .ToList();
        }
        //sobrescrita de método (OVERRIDE)
        public override List<Produto> Consultar(Func<Produto, bool> where)
        {
            //retornar uma consulta de Produtos fazendo
            //JOIN com a entidade Estoque
            return dataContext.Produto
            .Include(p => p.Estoque) //JOIN..
            .Where(where)
            .ToList();
        }
        //sobrescrita de método (OVERRIDE)
        public override Produto Obter(Func<Produto, bool> where)
        {
            //retornar uma consulta de Produtos fazendo
            //JOIN com a entidade Estoque
            return dataContext.Produto
            .Include(p => p.Estoque) //JOIN..
            .Where(where)
            .FirstOrDefault();
        }
        //sobrescrita de método (OVERRIDE)
        public override Produto ObterPorId(int id)
        {
            //retornar uma consulta de Produtos fazendo
            //JOIN com a entidade Estoque
            return dataContext.Produto
            .Include(p => p.Estoque) //JOIN..
            .FirstOrDefault(p => p.IdEstoque == id);
        }
    }
}