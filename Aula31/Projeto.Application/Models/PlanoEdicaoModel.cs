using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //validações
namespace Projeto.Application.Models
{
    public class PlanoEdicaoModel
    {
        [Required(ErrorMessage = "Por favor, informe o id do plano.")]
        public int IdPlano { get; set; }
        [Required(ErrorMessage = "Por favor, informe o nome do plano.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe a descrição do plano.")]
        public string Descricao { get; set; }
    }
}