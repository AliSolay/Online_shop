using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.HomePages.Sliders.Command.EditSlider
{
    public interface IEditSliderSevice
    {
        ResultDto Execute(RequestEditSliderDto request);
    }

    public class EditSliderSevice : IEditSliderSevice
    {
        private readonly IDataBaseContext _context;
        public EditSliderSevice(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(RequestEditSliderDto request)
        {
            var slider = _context.Sliders.Find(request.Id);
            if (slider == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد"
                };

            }
            slider.Src = request.Src;
            slider.Link = request.Link;
            slider.UpdateTime = DateTime.Now;
            _context.SaveChanges();

            return new ResultDto
            {
                IsSuccess = true,
                Message = "ویرایش اسلایدر موفقیت امیز بود"
            };
        }
    }

    public class RequestEditSliderDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
