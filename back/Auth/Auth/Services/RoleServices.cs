using Auth.Models.Role;
using Auth.Repositories;
using Auth.Utils;
using System.Net;

namespace Auth.Services
{
    public class RoleServices
    {
        private readonly IRoleRespository _repo;

        public RoleServices(IRoleRespository repo)
        {
            _repo = repo;
        }

        public async Task<Role> GetOneByName(string name)
        {
            var role = await _repo.GetOneAsync(x => x.Name == name);

            if(role == null)
            {
                throw new HttpResponseError(HttpStatusCode.NotFound, $"Role with name {name} doesn't exist");
            }
            return role;
        }
    }
}
