using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.hroads.webApi.Domains;
using senai.hroads.webApi.Interfaces;
using senai.hroads.webApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace senai.hroads.webApi.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class ClasseHabilidadesController : ControllerBase
    {
        private IClassHabilidades _IClassHabilidades { get; set; }

        public ClasseHabilidadesController()
        {
            _IClassHabilidades = new ClassHabilidadeRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_IClassHabilidades.ListarClasseHabilidades());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_IClassHabilidades.BuscarPorId(id));
        }

        [HttpPost]

        public IActionResult Post(ClassesHabilidade NovaClassHabilidade)
        {
            _IClassHabilidades.CadastrarClasseHabilidades(NovaClassHabilidade);

            return StatusCode(201);


        }

        [HttpPut("id")]

        public IActionResult Put(int id, ClassesHabilidade ClassHabilidadeAtualizada)
        {
            _IClassHabilidades.AtualizarClasseHabilidades(id, ClassHabilidadeAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("id")]

        public IActionResult Delete(int id)
        {
           _IClassHabilidades.DeletarClasseHabilidades(id);

            return StatusCode(204);
        }

    }
}

