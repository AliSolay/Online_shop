using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Command.RegisterUsers
{
    public interface IRegisterUserService
    {
        ResultDto<ResultRegisterUserServiceDto> Execute(RequestRegisterUserServiceDto requset);
    }
}
