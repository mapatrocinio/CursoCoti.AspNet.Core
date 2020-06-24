using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Projeto.Services.Mappings
{
    //classe de mapeamento do AutoMapper de forma a permitir
    //que classes de modelo (Models) possam transferir seus dados
    //para classes de entidade (Entities)
    public class ModelToEntityMapping : Profile
    {
        //construtor -> ctor + 2x[tab]
        public ModelToEntityMapping()
        {
            CreateMap<EstoqueCadastroModel, Estoque>();
            CreateMap<ProdutoCadastroModel, Produto>();
            CreateMap<EstoqueEdicaoModel, Estoque>();
            CreateMap<ProdutoEdicaoModel, Produto>();
            CreateMap<LoteCadastroModel, Estoque>()
            .AfterMap((src, dest) => dest.Nome = src.Estoque);
            CreateMap<ItemLoteCadastroModel, Produto>();
        }
    }
}