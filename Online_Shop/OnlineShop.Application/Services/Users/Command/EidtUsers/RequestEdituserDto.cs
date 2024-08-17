using OnlineShop.Application.Services.Users.Command.RegisterUsers;

namespace OnlineShop.Application.Services.Users.Command.EidtUsers
{
    public class RequestEdituserDto
    {
        public DateTime InsertTime { get; set; }
        public long userId { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public List<RolesName> roles { get; set; }
    }

    public class RolesName
    {
        public string Name { get; set; }
    }
}
