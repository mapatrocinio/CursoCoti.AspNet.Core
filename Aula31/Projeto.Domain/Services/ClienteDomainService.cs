using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
namespace Projeto.Domain.Services
{
    public class ClienteDomainService
    : BaseDomainService<ClienteEntity>, IClienteDomainService
    {
        //atributo..
        private readonly IClienteRepository repository;
        //construtor para injeção de dependência (inicialização)
        public ClienteDomainService(IClienteRepository repository)
        : base(repository) //construtor da superclasse
        {
            this.repository = repository;
        }
        //sobrescrita do método de cadastro
        public override void Cadastrar(ClienteEntity obj)
        {
            //verificando se o cliente é maior de idade
            if (ObterIdade(obj.DataNascimento) >= 18)
            {
                repository.Create(obj);
            }
            else
            {
                throw new Exception("Erro ao cadastrar: O Cliente deve ser maior de idade.");
            }
        }
        //sobrescrita do método de edição
        public override void Atualizar(ClienteEntity obj)
        {
            //verificando se o cliente é maior de idade
            if (ObterIdade(obj.DataNascimento) >= 18)
            {
                repository.Update(obj);
            }
            else
            {
                throw new Exception("Erro ao atualizar: O Cliente deve ser maior de idade.");
            }
        }
        //método private (somente da classe)
        private int ObterIdade(DateTime dataNascimento)
        {
            var idade = DateTime.Now.Year - dataNascimento.Year;
            //verificar se o cliente não fez aniversario
            if (DateTime.Now.DayOfYear < dataNascimento.DayOfYear)
            {
                //descontar 1 ano na idade
                idade = idade - 1;
            }
            return idade;
        }
    }
}