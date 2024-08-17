using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Common.HomePage;
using OnlineShop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.HomePages.Command.EditHomePageImage
{
    public interface IEditHomePageImageService
    {
        ResultDto Execute(RequestHomePageDto request);
    }

    public class EditHomePageImageService : IEditHomePageImageService
    {
        private readonly IDataBaseContext _context;
        public EditHomePageImageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestHomePageDto request)
        {
            var result = _context.HomePageImages.Find(request.Id);
            if (result == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "موردی یافت نشد"
                };
            }
            result.Link = request.Link;
            result.Src = request.Src;
            result.ImageLocation = request.Location;
            result.UpdateTime = DateTime.Now;
            return new ResultDto
            {
                IsSuccess = true,
                Message = "ویرایش مورد نظر انجام شد"
            };

        }
    }

    public class RequestHomePageDto
    {
        public long Id { get; set; }
        public string Link { get; set; }
        public string Src { get; set; }
        public ImageLocation Location { get; set; }
    }
}
