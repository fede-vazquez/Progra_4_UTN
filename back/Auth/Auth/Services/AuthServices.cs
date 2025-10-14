using Auth.Models.User;
using Auth.Models.User.Dto;
using Auth.Utils;
using System.Net;

namespace Auth.Services
{
    public class AuthServices
    {
        private readonly UserServices _userServices;
        private readonly IEncoderServices _encoderServices;

        public AuthServices(UserServices userServices, IEncoderServices encoderServices)
        {
            _userServices = userServices;
            _encoderServices = encoderServices;
        }

        async public Task<User> Register(RegisterDTO register)
        {
            var user = await _userServices.GetOneByEmailOrUsername(register.Email, register.UserName);
            if (user != null)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "El email o username ya esta en uso.");
            }

            var created = await _userServices.CreateOne(register);
            return created;
        }

        async public Task<LoginResponseDTO> Login(LoginDTO login)
        {
            string datum = login.EmailOrUsername;

            var user = await _userServices.GetOneByEmailOrUsername(datum, datum);

            if (user == null)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Invalid credentials");
            }

            bool IsMatch = _encoderServices.Verify(login.Password, user.Password);

            if (!IsMatch)
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Invalid credentials");
            }

            return new LoginResponseDTO { Success = true };
        }
    }
}
