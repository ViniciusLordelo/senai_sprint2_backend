using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Peoples.WebApi.Domains;
using Senai.Peoples.WebApi.Interfaces;
using Senai.Peoples.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class FuncionariosController : ControllerBase
    {
        private IFuncionarioRepository _FuncionarioRepository { get; set; }

        public FuncionariosController()
        {
            _FuncionarioRepository = new FuncionarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            List<FuncionarioDomain> ListaFuncionarios = _FuncionarioRepository.ListarFuncionarios();

            return Ok(ListaFuncionarios);
        }


        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            FuncionarioDomain funcionario = _FuncionarioRepository.BuscarPorId(Id);

            if(funcionario == null)
            {
                return NotFound("Funcionário não encontrado");
            }

            return Ok(funcionario);
        }


        [HttpPut("{Id}")]
        public IActionResult AtualizarIdURL (int Id, FuncionarioDomain FuncionarioAtualizado)
        {
            _FuncionarioRepository.AtualizarIdURL(Id, FuncionarioAtualizado);

            return NoContent();
        }

        [HttpPost]
        public IActionResult Cadastrar(FuncionarioDomain NovoFuncionario)
        {
            _FuncionarioRepository.Cadastrar(NovoFuncionario);

            return StatusCode(201);
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            _FuncionarioRepository.Deletar(Id);

            return StatusCode(204);
        }
    }
}
