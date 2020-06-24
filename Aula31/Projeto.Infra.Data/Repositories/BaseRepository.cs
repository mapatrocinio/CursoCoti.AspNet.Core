using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Projeto.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
    where TEntity : class
    {
        //atributo
        private readonly DataContext context;
        //construtor para injeção de dependência
        public BaseRepository(DataContext context)
        {
            this.context = context;
        }
        public virtual void Create(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Added;
            context.SaveChanges();
        }
        public virtual void Update(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Modified;
            context.SaveChanges();
        }
        public virtual void Delete(TEntity obj)
        {
            context.Entry(obj).State = EntityState.Deleted;
            context.SaveChanges();
        }
        public virtual List<TEntity> GetAll()
        {
            return context.Set<TEntity>().ToList();
        }
        public virtual List<TEntity> GetAll(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>()
            .Where(where)
            .ToList();
        }
        public virtual TEntity Get(Func<TEntity, bool> where)
        {
            return context.Set<TEntity>()
            .FirstOrDefault(where);
        }
        public virtual TEntity GetById(int id)
        {
            return context.Set<TEntity>()
            .Find(id);
        }
    }
}