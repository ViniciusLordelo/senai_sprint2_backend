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
    public class ClassController : ControllerBase
    {
        private IClass _IClass { get; set; }

        public ClassController()
        {
            _IClass = new ClassRepository();
        }
        [HttpGet]

        public IActionResult Get()
        {
            return Ok(_IClass.ListarClasses());
        }

        [HttpGet("{id}")]

        public IActionResult GetById(int id)
        {
            return Ok(_IClass.BuscarPorId(id));
        }

        [HttpPost]

        public IActionResult Post(Class NovaClass)
        {
            _IClass.CadastrarClasses(NovaClass);

            return StatusCode(201);


        }

        [HttpPut("id")]

        public IActionResult Put(int id, Class ClassAtualizada)
        {
            _IClass.AtualizarClasses(id, ClassAtualizada);

            return StatusCode(204);
        }

        [HttpDelete("id")]

        public IActionResult Delete(int id)
        {
            _IClass.DeletarClasses(id);

            return StatusCode(204);
        }

    }
}
