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
        public ActionResult<List<CinesDTO>> GetAll() {
            var cines = _services.GetAll();
            return Ok(cines);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cine), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        public ActionResult<Cine> GetOneById(int id)
        {
            try
            {
                var cine = _services.GetOneById(id);
                return Ok(cine);
            }
            catch (Exception ex)
            {
                return NotFound(new HttpMessage { Message = ex.Message });
            }
            catch
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage { Message = "Algo salío mal"});
            }
        }
    }
}
