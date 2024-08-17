using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.HomePages.Command.RemoveHomePage
{
    public interface IRemoveHomePageService
    {
        ResultDto Execute(long Id);
    }

    public class RemoveHomePageService : IRemoveHomePageService
    {
        private readonly IDataBaseContext _context;
        public RemoveHomePageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var homepageImage = _context.HomePageImages.Find(Id);
            if (homepageImage == null)
            {
                new ResultDto
                {
                    IsSuccess = false,
                    Message = "موردی یافت نشد"
                };
            }
            homepageImage.RemoveTime = DateTime.Now;
            homepageImage.IsRemoved = true;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "عملیات موفقیت آمیز بود"
            };
        }
    }
}
