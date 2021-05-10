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
    public class HabilidadeController : ControllerBase
    {
        private IHabilidadeRepository _HabilidadeRepository { get; set; }

        public HabilidadeController()
        {
            _HabilidadeRepository = new HabilidadeRepository();
        }


        /// <summary>
        /// Cadastra uma nova habilidade
        /// </summary>
        /// <param name="HabilidadeNovo">Objeot do tipo Habilidade</param>
        /// <returns>Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Habilidade HabilidadeNovo)
        {
            try
            {
                _HabilidadeRepository.Create(HabilidadeNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

        
        /// <summary>
        /// Lista todas as habilidades
        /// </summary>
        /// <returns>Uma lista de habilidades</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_HabilidadeRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca uma habilidade pelo Id
        /// </summary>
        /// <param name="Id">Id da hablidade bsucada</param>
        /// <returns>Uma hablidade E Status Code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_HabilidadeRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza uma habilidade
        /// </summary>
        /// <param name="HabilidadeNovo">Objeto tipo Habilidade contendo as novas informações</param>
        /// <param name="Id">Id da hablidade bsucada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(Habilidade HabilidadeNovo, int Id)
        {
            try
            {
                _HabilidadeRepository.Update(HabilidadeNovo, Id);

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
        /// <param name="Id">Id da hablidade bsucada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _HabilidadeRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
