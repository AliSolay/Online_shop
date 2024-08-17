using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.domain.Entities.HomePages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.HomePages.Sliders.Command.RemoveSlider
{
    public interface IRemoveSliderSevice
    {
        ResultDto Execute(long Id);
    }

    public class RemoveSliderSevice : IRemoveSliderSevice
    {
        private readonly IDataBaseContext _context;
        public RemoveSliderSevice(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto Execute(long Id)
        {
            var slider = _context.Sliders.Find(Id);
            if (slider == null)
            {
                return new ResultDto
                {
                    IsSuccess = false,
                    Message = "کاربر یافت نشد",
                };
            }
            slider.IsRemoved = true;
            slider.RemoveTime = DateTime.Now;
            _context.SaveChanges();
            return new ResultDto
            {
                IsSuccess = true,
                Message = "اسلاید با موفقیت حذف شد",
            };
        }
    }
}
