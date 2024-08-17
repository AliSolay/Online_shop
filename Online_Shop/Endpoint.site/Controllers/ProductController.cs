using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Products.Queries.GetProductsForSite;

namespace Endpoint.site.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductFacad _productFacad;
        public ProductController(IProductFacad productFacad)
        {
            _productFacad = productFacad;
        }

        public IActionResult Index(Ordering ordering, string Searchkey, long? CatId = null, int page = 1, int pageSize = 20)
        {
            return View(_productFacad.GetProductForSiteService.Execute(ordering, Searchkey, page, pageSize, CatId).Data);
        }

        public IActionResult Detail(long Id)
        {
            var detail = _productFacad.GetProductDetailForSiteService.Execute(Id).Data;
            return View(detail);
        }
    }
}
