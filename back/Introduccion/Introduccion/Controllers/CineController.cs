using Introduccion.Models;
using Introduccion.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Introduccion.Controllers
{
    [Route("api/cines")]
    [ApiController()]
    public class CineController : ControllerBase
    {
        private readonly IServices<Cine> _services;
        public CineController(IServices<Cine> services) {
            _services = services;
        }

        [HttpGet]
        public ActionResult<List<Cine>> GetAll() {
            var cines = _services.GetAll();
            return Ok(cines);
        }
    }
}
