using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Command.DeleteUsers
{
    public interface IDeleteUserService
    {
        ResultDto Execute(long userId);
    }
}

