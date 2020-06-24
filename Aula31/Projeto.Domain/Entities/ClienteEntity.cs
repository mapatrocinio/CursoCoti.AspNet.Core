using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Domain.Entities
{
    public class ClienteEntity
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public int IdPlano { get; set; }
        #region Relacionamentos
        public PlanoEntity Plano { get; set; }
        #endregion
    }
}