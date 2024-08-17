using OnlineShop.Application.Services.common.Querry.GetHomePage;
using OnlineShop.Application.Services.common.Querry.GetSliderList;
using OnlineShop.Application.Services.Products.Queries.GetProductsForSite;

namespace Endpoint.site.Models.ViewModels.HomePages
{
    public class HomePageViewModel
    {
        public List<SliderDto> Sliders { get; set; }
        public List<HomePageImageDto> PageImages { get; set; }
        public List<ProductForSiteDto> Camera { get; set; }
        public List<ProductForSiteDto> Mobile { get; set; }
        public List<ProductForSiteDto> Laptop { get; set; }
    }
}
