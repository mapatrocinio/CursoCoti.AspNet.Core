using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Application.Contracts
{
    public interface IClienteApplicationService
    {
        void Cadastrar(ClienteCadastroModel model);
        void Atualizar(ClienteEdicaoModel model);
        void Excluir(int idCliente);
        List<ClienteConsultaModel> Consultar();
        ClienteConsultaModel ObterPorId(int idCliente);
    }
}