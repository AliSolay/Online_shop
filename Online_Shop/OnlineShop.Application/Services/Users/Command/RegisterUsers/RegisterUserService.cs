using System.Text.RegularExpressions;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.Common.Service;
using OnlineShop.domain.Entities.Users;

namespace OnlineShop.Application.Services.Users.Command.RegisterUsers
{
    public class RegisterUserService : IRegisterUserService
    {
        private readonly IDataBaseContext _context;


        public RegisterUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ResultRegisterUserServiceDto> Execute(RequestRegisterUserServiceDto request)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(request.FullName))
                {
                    return new ResultDto<ResultRegisterUserServiceDto>
                    {
                        Data = new ResultRegisterUserServiceDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "لطفا نام کاربر را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Email))
                {
                    return new ResultDto<ResultRegisterUserServiceDto>()
                    {
                        Data = new ResultRegisterUserServiceDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "لطفا ایمیل را وارد کنید"
                    };
                }

                if (string.IsNullOrWhiteSpace(request.Password))
                {
                    return new ResultDto<ResultRegisterUserServiceDto>
                    {
                        Data = new ResultRegisterUserServiceDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "لطفا رمز عبور را وارد کنید"
                    };
                }

                if (request.Password != request.RePassword)
                {
                    return new ResultDto<ResultRegisterUserServiceDto>
                    {
                        Data = new ResultRegisterUserServiceDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "رمز عبور باید یکسان باشد"
                    };
                }

                string emailRegex = @"^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[A-Z0-9.-]+\.[A-Z]{2,}$";

                var match = Regex.Match(request.Email, emailRegex, RegexOptions.IgnoreCase);
                if (!match.Success)
                {
                    return new ResultDto<ResultRegisterUserServiceDto>()
                    {
                        Data = new ResultRegisterUserServiceDto()
                        {
                            UserId = 0,
                        },
                        IsSuccess = false,
                        Message = "ایمیل خودرا به درستی وارد نمایید"
                    };
                }

                var passwordHasher = new PasswordHasher();
                var hashedPassword = passwordHasher.HashPassword(request.Password);

                User user = new User()
                {
                    Email = request.Email,
                    FullName = request.FullName,
                    Password = hashedPassword,
                    IsActive = true,
                };
                List<UserInRole> userInRoles = new List<UserInRole>();
                foreach (var item in request.roles)
                {
                    var roles = _context.Roles.Find(item.Id);
                    userInRoles.Add(new UserInRole
                    {
                        Role = roles,
                        RoleId = roles.Id,
                        User = user,
                        UserId = user.Id,

                    });
                }
                user.UserInRoles = userInRoles;

                _context.Users.Add(user);
                _context.SaveChanges();

                return new ResultDto<ResultRegisterUserServiceDto>()
                {
                    Data = new ResultRegisterUserServiceDto()
                    {
                        UserId = user.Id,
                    },
                    IsSuccess = true,
                    Message = "ثبت نام کاربر انجام شد"
                };
            }
            catch (Exception)
            {

                return new ResultDto<ResultRegisterUserServiceDto>
                {
                    Data = new ResultRegisterUserServiceDto()
                    {
                        UserId = 0,
                    },
                    IsSuccess = false,
                    Message = "ثبت نام کاربر انجام نشد!"
                };
            }
        }
    }
}
