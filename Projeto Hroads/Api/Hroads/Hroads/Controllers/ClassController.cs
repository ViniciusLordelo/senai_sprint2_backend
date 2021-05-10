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
    public class ClassController : ControllerBase
    {

        private IClassRepository _IClassRepository { get; set; }

        public ClassController()
        {
            _IClassRepository = new ClassRepository();
        }


        /// <summary>
        /// Cadastra uma nova classe
        /// </summary>
        /// <param name="ClassNovo">Objeto do tipo Class</param>
        /// <returns>Status Code 201 - Created</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Post(Class ClassNovo)
        {
            try
            {
                _IClassRepository.Create(ClassNovo);

                return StatusCode(201);

            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Lista todas as classes
        /// </summary>
        /// <returns>Uma lista de classes</returns>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_IClassRepository.Read());
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Busca pelo ID
        /// </summary>
        /// <param name="Id">Id da classe buscada</param>
        /// <returns>Status Code 200 - Ok E Uma classe</returns>
        [HttpGet("{Id}")]
        public IActionResult GetById(int Id)
        {
            try
            {
                return Ok(_IClassRepository.ReadById(Id));
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Atualiza uma classe
        /// </summary>
        /// <param name="ClassAtualizado">Objeto do tipo Class contendo as novas informações</param>
        /// <param name="Id">Id da classe buscada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpPut("{Id}")]
        public IActionResult Put(Class ClassAtualizado, int Id)
        {
            try
            {
                _IClassRepository.Update(ClassAtualizado, Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }


        /// <summary>
        /// Exclui uma classe
        /// </summary>
        /// <param name="Id">Id da classe buscada</param>
        /// <returns>Status Code 204 - No Content</returns>
        [HttpDelete("{Id}")]
        public IActionResult Delete(int Id)
        {
            try
            {
                _IClassRepository.Delete(Id);

                return StatusCode(204);
            }
            catch (Exception ex)
            {

                return BadRequest(ex);
            }
        }
    }
}
