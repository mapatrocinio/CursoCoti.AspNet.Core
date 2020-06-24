using Projeto.Domain.Contracts.Repositories;
using Projeto.Domain.Contracts.Services;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Domain.Services
{
    public class PlanoDomainService
    : BaseDomainService<PlanoEntity>, IPlanoDomainService
    {
        //atributo..
        private readonly IPlanoRepository repository;
        //construtor para injeção de dependência (inicialização)
        public PlanoDomainService(IPlanoRepository repository)
        : base(repository) //construtor da superclasse
        {
            this.repository = repository;
        }
    }
}