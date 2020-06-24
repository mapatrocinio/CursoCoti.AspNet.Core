using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Domain.Services
{
    public class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
    where TEntity : class
    {
        //atributo
        private readonly IBaseRepository<TEntity> repository;
        //construtor para injeção de dependência (inicialização)
        public BaseDomainService(IBaseRepository<TEntity> repository)
        {
            this.repository = repository;
        }
        public virtual void Cadastrar(TEntity obj)
        {
            repository.Create(obj);
        }
        public virtual void Atualizar(TEntity obj)
        {
            repository.Update(obj);
        }
        public virtual void Excluir(TEntity obj)
        {
            repository.Delete(obj);
        }
        public virtual List<TEntity> Consultar()
        {
            return repository.GetAll();
        }
        public virtual TEntity ObterPorId(int id)
        {
            return repository.GetById(id);
        }
    }
}