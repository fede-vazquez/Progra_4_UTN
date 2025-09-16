using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using pancheria.Models.Pancho;
using pancheria.Models.Pancho.Dto;
using pancheria.Services;
using pancheria.Utils;

namespace pancheria.Controllers
{
    [ApiController]
    [Route("api/panchos")]
    public class PanchoController : ControllerBase
    {
        private IPanchoServices _panchoServices;
        public PanchoController(IPanchoServices panchoServices) {
            this._panchoServices = panchoServices;
        }

        [HttpGet]
        public ActionResult<List<PanchosDTO>> GetAll()
        {
            return _panchoServices.GetPanchos();
        }

        [HttpGet("{id}")]
        public ActionResult<Pancho> GetPanchoById(int id)
        {
            try
            {
                var pancho = _panchoServices.GetPanchoById(id);
                return Ok(pancho);

            }catch (Exception ex)
            {
                return NotFound(new HttpMessage { Message = ex.Message });
            }
        }

        [HttpGet("/aderezos/{aderezo}")]
        public ActionResult<Pancho> Get(string aderezo)
        {
            try
            {
                var panchos = _panchoServices.GetPanchosPorAderezo(aderezo);

                return Ok(panchos);

            }
            catch (Exception ex)
            {
                return NotFound(new HttpMessage { Message = ex.Message });
            }
        }
    }
}
