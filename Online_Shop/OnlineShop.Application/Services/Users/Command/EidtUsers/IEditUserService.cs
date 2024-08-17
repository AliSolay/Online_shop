using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Command.EidtUsers
{
    public interface IEditUserService
    {
        ResultDto Execute(RequestEdituserDto request);
    }
}
