using Auth.Enums;
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
        private readonly RoleServices _roleServices;

        public UserServices(IUserRepository repo, IMapper mapper, IEncoderServices encoderServices, RoleServices roleServices)
        {
            _repo = repo;
            _mapper = mapper;
            _encoderServices = encoderServices;
            _roleServices = roleServices;
        }

        async public Task<User> GetOneByEmailOrUsername(string? email, string? username)
        {
            // Solucionar este error.
            if (string.IsNullOrEmpty(email) && string.IsNullOrEmpty(username))
            {
                throw new HttpResponseError(HttpStatusCode.BadRequest, "Email and username are empty");
            }
            
            var User = await _repo.GetOneAsync(x => x.Email == email || x.UserName == username);
            
            return User;
        }
        async public Task<UserWithoutPassDTO> CreateOne(RegisterDTO register)
        {
            var user = _mapper.Map<User>(register);

            user.Password = _encoderServices.Encode(user.Password);

            var role = await _roleServices.GetOneByName(ROLE.USER);

            user.Roles.Add(role);

            await _repo.CreateOneAsync(user);

            return _mapper.Map<UserWithoutPassDTO>(user);
        }
    }
}
