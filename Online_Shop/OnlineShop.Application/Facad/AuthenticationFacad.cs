using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Users.Command.RegisterUsers;
using OnlineShop.Application.Services.Users.Command.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Facad
{
    public class AuthenticationFacad : IAuthenticationFacad
    {
        private readonly IDataBaseContext _context;
        public AuthenticationFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IRegisterUserService _registerUserService;
        public IRegisterUserService RegisterUserService
        {
            get
            {
                return _registerUserService = _registerUserService ?? new RegisterUserService(_context);
            }
        }

        private IUserLoginService _userLoginService;
        public IUserLoginService UserLoginService
        {
            get
            {
                return _userLoginService = _userLoginService ?? new UserLoginService(_context);
            }
        }


    }
}
