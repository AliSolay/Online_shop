using OnlineShop.Application.Services.Users.Command.RegisterUsers;
using OnlineShop.Application.Services.Users.Command.UserLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface IAuthenticationFacad
    {
        IUserLoginService UserLoginService { get; }
        IRegisterUserService RegisterUserService { get; }
    }
}
