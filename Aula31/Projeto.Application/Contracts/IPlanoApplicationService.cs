using Projeto.Application.Models;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Application.Contracts
{
    public interface IPlanoApplicationService
    {
        void Cadastrar(PlanoCadastroModel model);
        void Atualizar(PlanoEdicaoModel model);
        void Excluir(int idPlano);
        List<PlanoConsultaModel> Consultar();
        PlanoConsultaModel ObterPorId(int idPlano);
    }
}