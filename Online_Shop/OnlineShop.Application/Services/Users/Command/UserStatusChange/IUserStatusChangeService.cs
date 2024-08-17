using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Command.UserStatusChange
{
    public interface IUserStatusChangeService
    {
        ResultDto Execute(long userId);
    }
}
