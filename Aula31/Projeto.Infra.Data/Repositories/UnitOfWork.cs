using Microsoft.EntityFrameworkCore.Storage;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Infra.Data.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        //atributos..
        private readonly DataContext context;
        private IDbContextTransaction transaction;
        //construtor para injeção de dependência
        public UnitOfWork(DataContext context)
        {
            this.context = context;
        }
        public void BeginTransaction()
        {
            transaction = context.Database.BeginTransaction();
        }
        public void Commit()
        {
            transaction.Commit();
        }
        public void Rollback()
        {
            transaction.Rollback();
        }
        public IClienteRepository ClienteRepository
        {
            get { return new ClienteRepository(context); }
        }
        public IPlanoRepository PlanoRepository
        {
            get { return new PlanoRepository(context); }
        }
    }
}