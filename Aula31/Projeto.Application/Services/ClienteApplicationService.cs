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
    public class ClienteApplicationService : IClienteApplicationService
    {
        //atributo
        private readonly IClienteDomainService domainService;
        //construtor para injeção de dependência (inicialização)
        public ClienteApplicationService(IClienteDomainService domainService)
        {
            this.domainService = domainService;
        }
        public void Cadastrar(ClienteCadastroModel model)
        {
            var cliente = Mapper.Map<ClienteEntity>(model);
            domainService.Cadastrar(cliente);
        }
        public void Atualizar(ClienteEdicaoModel model)
        {
            var cliente = Mapper.Map<ClienteEntity>(model);
            domainService.Atualizar(cliente);
        }
        public void Excluir(int idCliente)
        {
            var cliente = domainService.ObterPorId(idCliente);
            domainService.Excluir(cliente);
        }
        public List<ClienteConsultaModel> Consultar()
        {
            var lista = domainService.Consultar();
            return Mapper.Map<List<ClienteConsultaModel>>(lista);
        }
        public ClienteConsultaModel ObterPorId(int idCliente)
        {
            var cliente = domainService.ObterPorId(idCliente);
            return Mapper.Map<ClienteConsultaModel>(cliente);
        }
    }
}