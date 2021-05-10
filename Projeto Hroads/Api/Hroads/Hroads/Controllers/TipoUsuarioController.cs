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
    public class TipoUsuarioController : ControllerBase
    {

        private ITipoUsuarioRepository _ITipoUsuarioRepository { get; set; }

        public TipoUsuarioController()
        {
            _ITipoUsuarioRepository = new TipoUsuarioRepository();
        }


        /// <summary>
        /// Cadastra um novo tipo de usuário
        /// </summary>
        /// <param name="TipoUsuarioNovo">Objeto do tipo TipoUsuario</param>
        /// <returns>Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(TipoUsuario TipoUsuarioNovo)
        {
            try
            {
                _ITipoUsuarioRepository.Create(TipoUsuarioNovo);

                return StatusCode(201);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todos os tipos de usuário
        /// </summary>
        /// <returns>Uma lista de tipos de usuário</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_ITipoUsuarioRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca um tipo de usuário
        /// </summary>
        /// <param name="Id">Id do tipo de usuário buscado</param>
        /// <returns>Um tipo de usuário</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_ITipoUsuarioRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza um tipo de usuário
        /// </summary>
        /// <param name="TipoUsuarioAtualizado">Objeto do tipo TipoUsuario contendo as novas informações</param>
        /// <param name="Id">Id do tipo de usuário buscado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(TipoUsuario TipoUsuarioAtualizado,int Id)
        {
            try
            {
                _ITipoUsuarioRepository.Update(TipoUsuarioAtualizado, Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui um tipo de usuário
        /// </summary>
        /// <param name="Id">Id do tipo de usuário buscado</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _ITipoUsuarioRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }

    }
}
