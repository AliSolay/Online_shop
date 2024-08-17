﻿using Microsoft.EntityFrameworkCore;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.domain.Entities.Users;

namespace OnlineShop.Application.Services.Users.Command.EidtUsers
{
    public class EditUserService : IEditUserService
    {
        private readonly IDataBaseContext _context;

        public EditUserService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEdituserDto request)
        {
            try
            {
                
                var user = _context.Users.Find(request.userId);
                if (user == null)
                {
                    return new ResultDto
                    {
                        IsSuccess = false,
                        Message = "کاربر یافت نشد"
                    };
                }

                user.FullName = request.Fullname;
                user.Email = request.Email;
                _context.SaveChanges();


                return new ResultDto()
                {
                    IsSuccess = true,
                    Message = "ویرایش کاربر انجام شد"
                };
            }
            catch (Exception)
            {

                return new ResultDto
                {

                    IsSuccess = false,
                    Message = "ایمیل شما تکراری است!"
                };

            }
        }
    }
}
