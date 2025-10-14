using Auth.Models.User;
using Auth.Models.User.Dto;
using Auth.Utils;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Net;
using System.Security.Claims;
using System.Text;

namespace Auth.Services
{
    public class AuthServices
    {
        private readonly UserServices _userServices;
        private readonly IEncoderServices _encoderServices;
        private readonly IConfiguration _config;
        internal readonly string _secret;

        public AuthServices(UserServices userServices, IEncoderServices encoderServices, IConfiguration config)
        {
            _userServices = userServices;
            _encoderServices = encoderServices;
            _config = config;
            _secret = _config.GetSection("Secrets:JWT")?.Value?.ToString() ?? string.Empty;
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

            string token = GenerateJwt(user);

            return new LoginResponseDTO { Token = token};
        }

        public string GenerateJwt(User user)
        {
            var key = Encoding.UTF8.GetBytes(_secret);
            var symmetricKey = new SymmetricSecurityKey(key);

            var credentials = new SigningCredentials(symmetricKey, SecurityAlgorithms.HmacSha256Signature);

            var claims = new ClaimsIdentity();
            claims.AddClaim(new Claim("id", user.Id.ToString()));

            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = credentials
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenConfig = tokenHandler.CreateToken(tokenDescriptor);
            string token = tokenHandler.WriteToken(tokenConfig);

            return token;
        }
    }
}
