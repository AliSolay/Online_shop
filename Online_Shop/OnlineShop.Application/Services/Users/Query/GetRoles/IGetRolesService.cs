using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Query.GetRoles
{
    public interface IGetRolesService
    {
        ResultDto<List<RolesDto>> Execute();
    }
}
