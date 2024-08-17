using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Users.Command.DeleteUsers
{
    public class DeleteUserService : IDeleteUserService
    {
        private readonly IDataBaseContext _context;
        public DeleteUserService(IDataBaseContext context)
        {
            _context = context;
        }

        public ResultDto Execute(long userId)
        {
            var user = _context.Users.Find(userId);
            if (user == null)
            {
                return new ResultDto()
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };
            }
            user.RemoveTime = DateTime.Now;
            user.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto()
            {

                IsSuccess = true,
                Message = "حذف کاربر با موفقیت انجام شد"
            };

        }
    }
}
