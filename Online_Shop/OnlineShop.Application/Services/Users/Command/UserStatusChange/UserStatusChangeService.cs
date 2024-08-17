using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Command.UserStatusChange
{
    public class UserStatusChangeService : IUserStatusChangeService
    {
        private readonly IDataBaseContext _context;
        public UserStatusChangeService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "تغییر وضعییت انجام نشد",
                };
            }
            user.IsActive = !user.IsActive;
            _context.SaveChanges();
            user.UpdateTime = DateTime.Now;
            var userState = user.IsActive == true ? "فعال" : "غیر فعال";
            return new ResultDto
            {
                IsSuccess = true,
                Message = $" کاربر با موفقیت {userState} شد"
            };
        }
    }
}
