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
    public class HabilidadesController : ControllerBase
    {
        private IHabilidade _IHabilidades { get; set; }

        public HabilidadesController()
        {
            _IHabilidades = new HabilidadesRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_IHabilidades.ListarHabilidades());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_IHabilidades.BuscarPorId(id));
        }

        [HttpPost]

        public IActionResult Post(Habilidade NovaHabilidade)
        {
            _IHabilidades.CadastrarHabilidades(NovaHabilidade);

            return StatusCode(201);


        }

        [HttpPut("id")]

        public IActionResult Put(int id, Habilidade HabilidadeAtualizada)
        {
            _IHabilidades.AtualizarHabilidades(id, HabilidadeAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("id")]

        public IActionResult Delete(int id)
        {
            _IHabilidades.DeletarHabilidades(id);

            return StatusCode(204);
        }

    }
}
    
