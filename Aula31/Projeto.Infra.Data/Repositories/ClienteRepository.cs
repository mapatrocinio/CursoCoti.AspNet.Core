using Microsoft.EntityFrameworkCore;
using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Entities;
using Projeto.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Projeto.Infra.Data.Repositories
{
    public class ClienteRepository
    : BaseRepository<ClienteEntity>, IClienteRepository
    {
        private readonly DataContext context;
        public ClienteRepository(DataContext context)
        : base(context) //construtor da superclasse
        {
            this.context = context;
        }
        public override List<ClienteEntity> GetAll()
        {
            return context.Cliente
            .Include(c => c.Plano) //INNER JOIN
            .ToList();
        }
        public override List<ClienteEntity>
        GetAll(Func<ClienteEntity, bool> where)
        {
            return context.Cliente
            .Include(c => c.Plano) //INNER JOIN
            .Where(where)
            .ToList();
        }
        public override ClienteEntity Get(Func<ClienteEntity, bool> where)
        {
            return context.Cliente
            .Include(c => c.Plano) //INNER JOIN
            .FirstOrDefault(where);
        }
        public override ClienteEntity GetById(int id)
        {
            return context.Cliente
            .Include(c => c.Plano) //INNER JOIN
            .FirstOrDefault(c => c.IdCliente == id);
        }
    }
}