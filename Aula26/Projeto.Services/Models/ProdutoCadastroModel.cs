using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações
namespace Projeto.Services.Models
{
    public class ProdutoCadastroModel
    {
        [Required(ErrorMessage = "Informe o Nome do Produto.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Informe o Preço do Produto.")]
        public decimal Preco { get; set; }
        [Required(ErrorMessage = "Informe a Quantidade do Produto.")]
        public int Quantidade { get; set; }
        [Required(ErrorMessage = "Informe o Id do Estoque do Produto.")]
        public int IdEstoque { get; set; }
    }
}