using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações
namespace Projeto.Services.Models
{
    public class EstoqueEdicaoModel
    {
        [Required(ErrorMessage = "Informe o Id do Estoque.")]
        public int IdEstoque { get; set; }
        [Required(ErrorMessage = "Informe o Nome do Estoque.")]
        public string Nome { get; set; }
    }
}