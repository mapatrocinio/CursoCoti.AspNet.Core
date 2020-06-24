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
    public class EstoqueController : ControllerBase
    {
        //atributo
        private readonly IEstoqueRepository estoqueRepository;
        private readonly IMapper mapper;
        //construtor para injeção de dependência
        public EstoqueController(IEstoqueRepository estoqueRepository,
        IMapper mapper)
        {
            this.estoqueRepository = estoqueRepository;
            this.mapper = mapper;
        }
        [HttpPost]
        public IActionResult Post(EstoqueCadastroModel model)
        {
            //verificando se os campos da model passaram nas validações
            if (ModelState.IsValid)
            {
                try
                {
                    var estoque = mapper.Map<Estoque>(model);
                    estoqueRepository.Inserir(estoque);
                    var result = new
                    {
                        message = "Estoque cadastrado com sucesso",
                        estoque
                    };
                    return Ok(result); //HTTP 200 (SUCESSO!)
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                //Erro HTTP 400 (BAD REQUEST)
                return BadRequest("Ocorreram erros de validação.");
            }
        }
        [HttpPut]
        public IActionResult Put(EstoqueEdicaoModel model)
        {
            //verificando se os campos da model passaram nas validações
            if (ModelState.IsValid)
            {
                try
                {
                    var estoque = mapper.Map<Estoque>(model);
                    estoqueRepository.Alterar(estoque);
                    var result = new
                    {
                        message = "Estoque atualizado com sucesso",
                        estoque
                    };
                    return Ok(result); //HTTP 200 (SUCESSO!)
                }
                catch (Exception e)
                {
                    return StatusCode(500, "Erro: " + e.Message);
                }
            }
            else
            {
                //Erro HTTP 400 (BAD REQUEST)
                return BadRequest("Ocorreram erros de validação.");
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                //buscar o estoque referente ao id informado..
                var estoque = estoqueRepository.ObterPorId(id);
                //verificar se o estoque foi encontrado..
                if (estoque != null)
                {
                    //excluindo o estoque
                    estoqueRepository.Excluir(estoque);
                    var result = new
                    {
                        message = "Estoque excluído com sucesso.",
                            estoque
                    };
                    return Ok(result);
                }
                else
                {
                    return BadRequest("Estoque não encontrado.");
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
                var result = mapper.Map<List<EstoqueConsultaModel>>
                (estoqueRepository.Consultar());
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
                var result = mapper.Map<EstoqueConsultaModel>
                (estoqueRepository.ObterPorId(id));
                if (result != null) //se o estoque foi encontrado..
                {
                    return Ok(result);
                }
                else
                {
                    return NoContent(); //HTTP 204 (SUCESSO -> Vazio)
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, "Erro: " + e.Message);
            }
        }
    }
}