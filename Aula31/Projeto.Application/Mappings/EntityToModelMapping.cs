using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Projeto.Application.Models;
using Projeto.Domain.Entities;
namespace Projeto.Application.Mappings
{
    public class EntityToModelMapping : Profile
    {
        //construtor -> ctor + 2x[tab]
        public EntityToModelMapping()
        {
            //consultas (saída de dados)
            CreateMap<PlanoEntity, PlanoConsultaModel>();
            CreateMap<ClienteEntity, ClienteConsultaModel>();
        }
    }
}