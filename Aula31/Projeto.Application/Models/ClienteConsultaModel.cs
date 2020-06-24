﻿using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Application.Models
{
    public class ClienteConsultaModel
    {
        public int IdCliente { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataNascimento { get; set; }
        public PlanoConsultaModel Plano { get; set; }
    }
}