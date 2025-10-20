namespace Auth.Models.User.Dto
{
    public class UserWithoutPassDTO
    {
        public int Id { get; set; }
        public string UserName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public List<Role.Role> Roles { get; set; } = new();
    }
}
