using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Data.Entities
{
    public class Estoque
    {
        public int IdEstoque { get; set; }
        public string Nome { get; set; }
        #region Associações
        public List<Produto> Produtos { get; set; }
        #endregion
    }
}