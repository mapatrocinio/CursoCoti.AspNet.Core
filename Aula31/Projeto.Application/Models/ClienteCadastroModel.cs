using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel.DataAnnotations; //validações
namespace Projeto.Application.Models
{
    public class ClienteCadastroModel
    {
        [Required(ErrorMessage = "Por favor, informe o nome do cliente.")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "Por favor, informe o cpf do cliente.")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "Por favor, informe a data de nascimento do cliente.")]
        public DateTime DataNascimento { get; set; }
        [Required(ErrorMessage = "Por favor, informe o plano do cliente.")]
        public int IdPlano { get; set; }
    }
}