using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Services.common.Querry.GetSliderList
{
    public interface IGetSliderListService
    {
        ResultDto<List<SliderDto>> Execute();
    }

    public class GetSliderListService : IGetSliderListService
    {
        private readonly IDataBaseContext _context;
        public GetSliderListService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<SliderDto>> Execute()
        {
            var slider = _context.Sliders.OrderByDescending(p => p.Id).Select(p => new SliderDto
            {
                Link = p.Link,
                Src = p.Src,
            }).ToList();

            return new ResultDto<List<SliderDto>>()
            {
                Data = slider,
                IsSuccess = true,
            };
        }
    }

    public class SliderDto
    {
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
