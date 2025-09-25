using Introduccion.Models.Cine;
using Introduccion.Models.Cine.DTO;
using Introduccion.Services;
using Introduccion.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Introduccion.Controllers
{
    [Route("api/cines")]
    [ApiController()]
    public class CineController : ControllerBase
    {
        private readonly ICineServices _services;
        public CineController(ICineServices services) {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<Cine>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CinesDTO>> GetAll() {
            try
            {
                var cines = _services.GetAll();
                return Ok(cines);
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cine), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<Cine> GetOneById(int id) {
            try
            {
                var cine = _services.GetOneById(id);
                return Ok(cine);
            }
            catch (HttpResponseError ex) {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpPost]
        [ProducesResponseType(typeof(Cine), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<Cine> CreateOne([FromBody]CreateCineDTO createDTO)
        {
            try
            {
                var cine = _services.CreateOne(createDTO);
                return Created("Create Cine", cine);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult DeleteOneById(int id)
        {
            try
            {
                _services.DeleteOneById(id);
                return Ok(new HttpMessage($"Cine con ID = {id} eliminado"));
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }

        [HttpPut("{id}")]
        [ProducesResponseType(typeof(Cine), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ValidationErrorResponse), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<Cine> UpdateOneById(int id, [FromBody]UpdateCineDTO updateDto)
        {
            try
            {
                var cine = _services.UpdateOneById(id, updateDto);
                return Ok(cine);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode(
                    (int)ex.StatusCode,
                    new HttpMessage(ex.Message)
                );
            }
            catch (Exception ex)
            {
                return StatusCode(
                    StatusCodes.Status500InternalServerError,
                    new HttpMessage(ex.Message)
                );
            }
        }
    }
}
