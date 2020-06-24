using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Data.Contracts;
using Projeto.Data.Entities;
using Projeto.Services.Models;
namespace Projeto.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoteController : ControllerBase
    {
        //atributos..
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        //construtor para injeção de dependência
        public LoteController(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        [HttpPost]
        public IActionResult Post(LoteCadastroModel model)
        {
            //verificar se todos os campos passaram nas regras de validação
            if (ModelState.IsValid)
            {
                unitOfWork.BeginTransaction(); //abrindo transação
                try
                {
                    //gravar estoque..
                    var estoque = mapper.Map<Estoque>(model);
                    unitOfWork.EstoqueRepository.Inserir(estoque);
                    //gravar os produtos..
                    foreach (var item in model.Produtos)
                    {
                        //gravar o produto
                        var produto = mapper.Map<Produto>(item);
                        produto.IdEstoque = estoque.IdEstoque;
                        //chave estrangeira
                        unitOfWork.ProdutoRepository.Inserir(produto);
                    }
                    unitOfWork.Commit(); //finalizar a transação
                    var result = new { message = "Lote cadastrado com sucesso." };
                    return Ok(result);
                }
                catch (Exception e)
                {
                    unitOfWork.Rollback(); //desfazer a transação
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação.");
            }
        }
    }
}