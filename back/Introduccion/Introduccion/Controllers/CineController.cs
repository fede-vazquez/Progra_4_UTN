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
        public CineController(ICineServices services)
        {
            _services = services;
        }

        [HttpGet]
        [ProducesResponseType(typeof(List<CinesDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<List<CinesDTO>> GetAll()
        {
            try
            {
                var cines = _services.GetAll();
                return Ok(cines);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }
        }

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Cine), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        public ActionResult<Cine> GetOneById(int id)
        {
            try
            {
                var cine = _services.GetOneById(id);
                return Ok(cine);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new HttpMessage(ex.Message));
            }
        }
    }
}