using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Common.HomePage;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.common.Querry.GetHomePage
{
    public interface IGetHomePageImageService
    {
        ResultDto<List<HomePageImageDto>> Execute();
    }

    public class GetHomePageImageService : IGetHomePageImageService
    {
        private readonly IDataBaseContext _context;
        public GetHomePageImageService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<HomePageImageDto>> Execute()
        {
            var image = _context.HomePageImages.OrderByDescending(p => p.Id).Select(c => new HomePageImageDto
            {
                Id = c.Id,
                Link = c.Link,
                Src = c.Src,
                ImageLocation = c.ImageLocation,
            }).ToList();

            return new ResultDto<List<HomePageImageDto>>
            {
                Data = image,
                IsSuccess = true,
            };
        }
    }

    public class HomePageImageDto
    {
        public long Id { get; set; }
        public string Link { get; set; }
        public string Src { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
}
