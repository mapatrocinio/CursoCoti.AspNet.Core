using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Domain.Contracts.Repositories
{
    public interface IBaseRepository<TEntity>
    where TEntity : class
    {
        void Create(TEntity obj);
        void Update(TEntity obj);
        void Delete(TEntity obj);
        List<TEntity> GetAll();
        List<TEntity> GetAll(Func<TEntity, bool> where);
        TEntity Get(Func<TEntity, bool> where);
        TEntity GetById(int id);
    }
}