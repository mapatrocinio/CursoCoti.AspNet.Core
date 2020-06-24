using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Domain.Entities
{
    public class PlanoEntity
    {
        public int IdPlano { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        #region Relacionamentos
        public List<ClienteEntity> Clientes { get; set; }
        #endregion
    }
}