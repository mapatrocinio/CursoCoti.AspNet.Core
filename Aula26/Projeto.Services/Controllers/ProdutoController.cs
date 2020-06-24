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
    public class ProdutoController : ControllerBase
    {
        //atributo
        private readonly IProdutoRepository produtoRepository;
        private readonly IMapper mapper;
        //construtor para injeção de dependência
        public ProdutoController(IProdutoRepository produtoRepository,
        IMapper mapper)
        {
            this.produtoRepository = produtoRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public IActionResult Post(ProdutoCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = mapper.Map<Produto>(model);
                    produtoRepository.Inserir(produto);
                    var result = new
                    {
                        message = "Produto cadastrado com sucesso.",
                        produto
                    };
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação.");
            }
        }
        [HttpPut]
        public IActionResult Put(ProdutoEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var produto = mapper.Map<Produto>(model);
                    produtoRepository.Alterar(produto);
                    var result = new
                    {
                        message = "Produto atualizado com sucesso.",
                        produto
                    };
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                return BadRequest("Ocorreram erros de validação.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var produto = produtoRepository.ObterPorId(id);
                if (produto != null)
                {
                    produtoRepository.Excluir(produto);
                    var result = new
                    {
                        message = "Produto excluído com sucesso.",
                        produto
                    };
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Produto não encontrado.");
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var result = mapper.Map<List<ProdutoConsultaModel>>
                (produtoRepository.Consultar());
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var result = mapper.Map<ProdutoConsultaModel>
                (produtoRepository.ObterPorId(id));
                if (result != null)
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent();
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}