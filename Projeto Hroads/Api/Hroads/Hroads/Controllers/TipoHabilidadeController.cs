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
    public class TipoHabilidadeController : ControllerBase
    {

        private ITipoHabilidadeRepository _ITipoHabilidadeRepository { get; set; }


        public TipoHabilidadeController()
        {
            _ITipoHabilidadeRepository = new TipoHabilidadeRepository();
        }


        /// <summary>
        /// Cadastra um novo tipo de habilidade
        /// </summary>
        /// <param name="TipoHabilidadeNovo">Objeto do tipo TipoHabilidade</param>
        /// <returns>Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoHabilidade TipoHabilidadeNovo)
        {
            try
            {
                _ITipoHabilidadeRepository.Create(TipoHabilidadeNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todos os tipos de habilidade
        /// </summary>
        /// <returns>Uma lista de tipos de habilidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITipoHabilidadeRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um tipo de habilidade pelo Id
        /// </summary>
        /// <param name="Id">Id do tipo de habilidade buscado</param>
        /// <returns>Um tipo de habilidade E Status Code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_ITipoHabilidadeRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza um tipo de habilidade
        /// </summary>
        /// <param name="TipoHabilidadeAtualizado">Objeot do tipo TipoHabilidade contendo as novas informações</param>
        /// <param name="Id">Id do tipo de hablidade buscado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(TipoHabilidade TipoHabilidadeAtualizado, int Id)
        {
            try
            {
                _ITipoHabilidadeRepository.Update(TipoHabilidadeAtualizado, Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um tipo de habilidade
        /// </summary>
        /// <param name="Id">Id do tipo de hablidade buscado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _ITipoHabilidadeRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
