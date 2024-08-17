using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.HomePages.Sliders.Querry.GetSliderAdmin
{
    public interface IGetSliderAdminService
    {
        ResultDto<List<RequestGetSliderDto>> Execute();
    }

    public class GetSliderAdminService : IGetSliderAdminService
    {
        private readonly IDataBaseContext _context;
        public GetSliderAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<RequestGetSliderDto>> Execute()
        {
            var slider = _context.Sliders.OrderByDescending(p => p.Id).Select(p => new RequestGetSliderDto
            {
                Id = p.Id,
                Link = p.Link,
                Src = p.Src,
            }).ToList();

            return new ResultDto<List<RequestGetSliderDto>>()
            {
                Data = slider,
                IsSuccess = true,
            };
        }
    }

    public class RequestGetSliderDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
        public string Link { get; set; }
    }
}
