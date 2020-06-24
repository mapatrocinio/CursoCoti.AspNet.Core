using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations; //validações
namespace Projeto.Services.Models
{
    public class LoteCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do estoque.")]
        public string Estoque { get; set; }
        public List<ItemLoteCadastroModel> Produtos { get; set; }
    }
}