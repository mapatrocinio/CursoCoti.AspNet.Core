using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace Projeto.Services.Models
{
    public class EstoqueCadastroModel
    {
        [Required(ErrorMessage = "Informe o nome do estoque.")]
        public string Nome { get; set; }
    }
}