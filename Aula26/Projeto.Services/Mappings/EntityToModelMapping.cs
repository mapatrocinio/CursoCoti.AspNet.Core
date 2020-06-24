using AutoMapper;
using Projeto.Data.Entities;
using Projeto.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
namespace Projeto.Services.Mappings
{
    public class EntityToModelMapping : Profile
    {
        //ctor + 2x[tab] --> construtor default
        public EntityToModelMapping()
        {
            CreateMap<Estoque, EstoqueConsultaModel>()
                .AfterMap((src, dest)
                    => dest.QuantidadeProdutos = src.Produtos.Count);
            CreateMap<Produto, ProdutoConsultaModel>()
                .AfterMap((src, dest)
                    => dest.Total = (src.Preco * src.Quantidade));
        }
    }
}