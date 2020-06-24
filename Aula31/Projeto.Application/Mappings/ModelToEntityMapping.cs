using AutoMapper;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
namespace Projeto.Application.Mappings
{
    public class ModelToEntityMapping : Profile
    {
        //construtor -> ctor + 2x[tab]
        public ModelToEntityMapping()
        {
            //entradas de dados (cadastro, edição, etc)
            CreateMap<PlanoCadastroModel, PlanoEntity>();
            CreateMap<ClienteCadastroModel, ClienteEntity>();
            CreateMap<PlanoEdicaoModel, PlanoEntity>();
            CreateMap<ClienteEdicaoModel, ClienteEntity>();
        }
    }
}