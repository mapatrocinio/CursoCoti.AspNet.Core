using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity>
    where TEntity : class
    {
        void Cadastrar(TEntity obj);
        void Atualizar(TEntity obj);
        void Excluir(TEntity obj);
        List<TEntity> Consultar();
        TEntity ObterPorId(int id);
    }
}