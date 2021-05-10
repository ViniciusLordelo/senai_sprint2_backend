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
    public class PersonagenController : ControllerBase
    {
        private IPersonagenRepository _IPersonagenRepository { get; set; }
        
        public PersonagenController()
        {
            _IPersonagenRepository = new PersonagenRepository();
        }


        /// <summary>
        /// Cadastra um novo personagem
        /// </summary>
        /// <param name="PersonagenNovo">Objeto tipo Personagen</param>
        /// <returns></returns>
        [Authorize(Roles = "2")]
        [HttpPost]
        public IActionResult Post(Personagen PersonagenNovo)
        {
            try
            {
                _IPersonagenRepository.Create(PersonagenNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// lista todos os personagens
        /// </summary>
        /// <returns>Uma lista de personagens E Status Code 200 - Ok</returns>
        [Authorize(Roles = "1, 2")]
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IPersonagenRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um personagem pelo IE
        /// </summary>
        /// <param name="Id">Id do personagem buscado</param>
        /// <returns>Um personagem E Status Code 200 - Ok</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IPersonagenRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza um personagem
        /// </summary>
        /// <param name="PersonagenNovo">objeot do tipo Personagen contendo as novas informações</param>
        /// <param name="Id">Id do personagem bsucado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(Personagen PersonagenNovo, int Id)
        {
            try
            {
                _IPersonagenRepository.Update(PersonagenNovo, Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um personagem
        /// </summary>
        /// <param name="Id">Id do personagem bsucado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IPersonagenRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
