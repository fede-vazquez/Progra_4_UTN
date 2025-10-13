using Auth.Models.User;
using Auth.Models.User.Dto;
using Auth.Repositories;
using Auth.Utils;
using AutoMapper;
using System.Net;

namespace Auth.Services
{
    public class UserServices
    {
        private readonly IUserRepository _repo;
        private readonly IMapper _mapper;
        private readonly IEncoderServices _encoderServices;

        public UserServices(IUserRepository repo, IMapper mapper, IEncoderServices encoderServices)
        {
            _repo = repo;
            _mapper = mapper;
            _encoderServices = encoderServices;
        }

        async public Task<User> GetOneByEmailOrUsername(string? email, string? username)
        {
            User user;
            // Solucionar este error.
            if (!string.IsNullOrEmpty(email))
            {
                user = await _repo.GetOneAsync(x => x.Email == email);
            }
            else if (!string.IsNullOrEmpty(username))
            {
                user = await _repo.GetOneAsync(x => x.UserName == username);
            }
            else
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Email and username are empty");
            }

            return user;
        }
        async public Task<User> CreateOne(RegisterDTO register)
        {
            var user = _mapper.Map<User>(register);

            user.Password = _encoderServices.Encode(user.Password);

            await _repo.CreateOneAsync(user);

            return user;
        }
    }
}
