using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Projeto.Application.Contracts;
using Projeto.Application.Models;
namespace Projeto.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        //atributo
        private readonly IClienteApplicationService service;
        //construtor para injeção de dependência
        public ClienteController(IClienteApplicationService service)
        {
            this.service = service;
        }
        [HttpPost]
        public IActionResult Post(ClienteCadastroModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Cadastrar(model);
                    var result = new
                    {
                        message = "Cliente cadastrado com sucesso" };
                        return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest(); //HTTP 400
            }
        }
        [HttpPut]
        public IActionResult Put(ClienteEdicaoModel model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    service.Atualizar(model);
                    var result = new
                    {
                        message = "Cliente atualizado com sucesso" };
                    return Ok(result);
                }
                catch (Exception e)
                {
                    return StatusCode(500, e.Message);
                }
            }
            else
            {
                return BadRequest(); //HTTP 400
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                service.Excluir(id);
                var result = new { message = "Cliente excluído com sucesso" };
                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(service.Consultar());
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(service.ObterPorId(id));
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }
    }
}