using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Entities
{
    public class Produto
    {
        public int IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public int IdEstoque { get; set; }
        #region Associações
        public Estoque Estoque { get; set; }
        #endregion
    }
}