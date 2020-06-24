using AutoMapper;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Application.Services
{
    public class PlanoApplicationService : IPlanoApplicationService
    {
        //atributo
        private readonly IPlanoDomainService domainService;
        //construtor para injeção de dependência
        public PlanoApplicationService(IPlanoDomainService domainService)
        {
            this.domainService = domainService;
        }
        public void Cadastrar(PlanoCadastroModel model)
        {
            var plano = Mapper.Map<PlanoEntity>(model);
            domainService.Cadastrar(plano);
        }
        public void Atualizar(PlanoEdicaoModel model)
        {
            var plano = Mapper.Map<PlanoEntity>(model);
            domainService.Atualizar(plano);
        }
        public void Excluir(int idPlano)
        {
            var plano = domainService.ObterPorId(idPlano);
            domainService.Excluir(plano);
        }
        public List<PlanoConsultaModel> Consultar()
        {
            var lista = domainService.Consultar();
            return Mapper.Map<List<PlanoConsultaModel>>(lista);
        }
        public PlanoConsultaModel ObterPorId(int idPlano)
        {
            var plano = domainService.ObterPorId(idPlano);
            return Mapper.Map<PlanoConsultaModel>(plano);
        }
    }
}