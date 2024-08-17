using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Users.Command.DeleteUsers;
using OnlineShop.Application.Services.Users.Command.EidtUsers;
using OnlineShop.Application.Services.Users.Command.RegisterUsers;
using OnlineShop.Application.Services.Users.Command.UserStatusChange;
using OnlineShop.Application.Services.Users.Query.GetRoles;
using OnlineShop.Application.Services.Users.Query.GetUsers;

namespace OnlineShop.Application.Facad
{
    public class UsersFacad : IUsersFacad
    {
        private readonly IDataBaseContext _context;
        public UsersFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IGetUsersService _getUsersService;
        public IGetUsersService GetUsersService
        {
            get
            {
                return _getUsersService = _getUsersService ?? new GetUsersService(_context);
            }
        }

        private IGetRolesService _getRolesService;
        public IGetRolesService GetRolesService
        {
            get
            {
                return _getRolesService = _getRolesService ?? new GetRolesService(_context);
            }
        }

        private IRegisterUserService _registerUserService;
        public IRegisterUserService RegisterUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);
            }
        }



        private IDeleteUserService _deleteUserService;
        public IDeleteUserService DeleteUserService
        {
            get
            {
                return _deleteUserService = _deleteUserService ?? new DeleteUserService(_context);
            }
        }

        private IUserStatusChangeService _userStatusChangeService;
        public IUserStatusChangeService UserStatusChangeService
        {
            get
            {
                return _userStatusChangeService = _userStatusChangeService ?? new UserStatusChangeService(_context);
            }
        }

        private IEditUserService _editUserService;
        public IEditUserService EditUserService
        {
            get
            {
                return _editUserService = _editUserService ?? new EditUserService(_context);
            }
        }
    }
}
