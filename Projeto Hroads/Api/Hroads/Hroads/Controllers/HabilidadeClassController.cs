using Hroads.Domains;
using Hroads.Interfaces;
using Hroads.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hroads.Controllers
{
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class HabilidadeClassController : ControllerBase
    {
        private IHabilidadeClassRepository _HabilidadeClassRepository { get; set; }

        public HabilidadeClassController()
        {
            _HabilidadeClassRepository = new HabilidadeClassRepository();
        }


        /// <summary>
        /// Cadastra uma nova HabilidadeClass
        /// </summary>
        /// <param name="HabilidadeClassNovo">Objeto do tipo HabilidadeClass</param>
        /// <returns>Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(HabilidadeClass HabilidadeClassNovo)
        {
            try
            {
                _HabilidadeClassRepository.Create(HabilidadeClassNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todas as classes de habilidades
        /// </summary>
        /// <returns>Uma lista de classes de hablidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_HabilidadeClassRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca pelo Id
        /// </summary>
        /// <param name="Id">Id da classe de habilidade buscada</param>
        /// <returns>Status Code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_HabilidadeClassRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza uma classe de habilidade
        /// </summary>
        /// <param name="HabilidadeClassAtualizado">Objeto do tipo HabilidadeClass contendo as novas informações</param>
        /// <param name="Id">Id da classe de habilidade buscada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(HabilidadeClass HabilidadeClassAtualizado,int Id)
        {
            try
            {
                _HabilidadeClassRepository.Update(HabilidadeClassAtualizado, Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        /// <summary>
        /// Exclui uma classe de habilidade
        /// </summary>
        /// <param name="Id">Id da classe de habilidade buscada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _HabilidadeClassRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
