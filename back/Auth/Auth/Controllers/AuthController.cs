using Auth.Models.User;
using Auth.Models.User.Dto;
using Auth.Services;
using Auth.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Auth.Controllers
{
    [Route("api/auth")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AuthServices _authServices;

        public AuthController(AuthServices authServices)
        {
            _authServices = authServices;
        }

        [HttpPost("register")]
        async public Task<ActionResult<User>> Register([FromBody] RegisterDTO register)
        {
            try
            {
                var created = await _authServices.Register(register);

                return Created("Register", created);
            }
            catch (HttpResponseError ex)
            {
                return StatusCode((int)ex.StatusCode, new HttpMessage(ex.Message));

            }
            catch (Exception ex)
            {
                return StatusCode((int)HttpStatusCode.InternalServerError, new HttpMessage(ex.Message));
            }
        }
    }
}
