using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Contracts
{
    public interface IUnitOfWork
    {
        void BeginTransaction();
        void Commit();
        void Rollback();
        IEstoqueRepository EstoqueRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
    }
}