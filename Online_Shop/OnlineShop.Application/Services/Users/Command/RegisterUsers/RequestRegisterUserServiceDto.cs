namespace OnlineShop.Application.Services.Users.Command.RegisterUsers
{
    public class RequestRegisterUserServiceDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string RePassword { get; set; }
        public List<RolesRegisterUserServiceDto> roles { get; set; }
    }
}
