using Auth.Enums;
using Auth.Models.User;
using Auth.Models.User.Dto;
using Auth.Services;
using Auth.Utils;
using Microsoft.AspNetCore.Authorization;
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
        [ProducesResponseType(typeof(User), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]

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

        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginResponseDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(HttpMessage), StatusCodes.Status500InternalServerError)]
        async public Task<ActionResult<LoginResponseDTO>> Login([FromBody] LoginDTO login)
        {
            try
            {
                return Ok(await _authServices.Login(login));
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

        [HttpGet("health")]
        [Authorize(Roles = $"{ROLE.USER}, {ROLE.MOD}")]
        //[AllowAnonymous] - Invalida el [Authorize]
        public bool Health()
        {
            return true;
        }
    }
}
