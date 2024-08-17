using OnlineShop.Application.Services.Users.Command.DeleteUsers;
using OnlineShop.Application.Services.Users.Command.EidtUsers;
using OnlineShop.Application.Services.Users.Command.RegisterUsers;
using OnlineShop.Application.Services.Users.Command.UserStatusChange;
using OnlineShop.Application.Services.Users.Query.GetRoles;
using OnlineShop.Application.Services.Users.Query.GetUsers;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface IUsersFacad
    {
        IGetUsersService GetUsersService { get; }
        IGetRolesService GetRolesService { get; }
        IRegisterUserService RegisterUserService { get; }
        IDeleteUserService DeleteUserService { get; }
        IUserStatusChangeService UserStatusChangeService { get; }
        IEditUserService EditUserService { get; }
    }

    
}
