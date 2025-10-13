using Auth.Models.User;
using Auth.Models.User.Dto;
using Auth.Utils;
using System.Net;

namespace Auth.Services
{
    public class AuthServices
    {
        private readonly UserServices _userServices;

        public AuthServices(UserServices userServices)
        {
            _userServices = userServices;
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
    }
}
