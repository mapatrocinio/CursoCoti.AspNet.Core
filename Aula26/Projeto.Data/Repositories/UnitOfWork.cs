using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Data.Contexts;
using Projeto.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext dataContext;
        private IDbContextTransaction transaction;
        public UnitOfWork(DataContext dataContext)
        {
            this.dataContext = dataContext;
        }
        public void BeginTransaction()
        {
            //abrir uma transação no banco de dados através do EF
            transaction = dataContext.Database.BeginTransaction();
        }
        public void Commit()
        {
            //executando e finalizando a transação
            transaction.Commit();
        }
        public void Rollback()
        {
            //desfazer a transação
            transaction.Rollback();
        }
        public IEstoqueRepository EstoqueRepository
        {
            get { return new EstoqueRepository(dataContext); }
        }
        public IProdutoRepository ProdutoRepository
        {
            get { return new ProdutoRepository(dataContext); }
        }
    }
}