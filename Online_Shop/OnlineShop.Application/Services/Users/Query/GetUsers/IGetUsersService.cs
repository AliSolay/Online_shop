using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Query.GetUsers
{
    public interface IGetUsersService
    {
        ReslutGetUserDto Execute(RequestPageDto request);
    }
}
