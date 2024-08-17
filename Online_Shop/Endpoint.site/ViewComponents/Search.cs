using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;

namespace Endpoint.site.ViewComponents
{
    public class Search : ViewComponent
    {
        private readonly ICommonFacad _commonFacad;
        public Search(ICommonFacad commonFacad)
        {
            _commonFacad = commonFacad;
        }


        public IViewComponentResult Invoke()
        {
            var resultSearch = _commonFacad.GetCategoryService.Execute().Data;
            return View(viewName: "Search",resultSearch);
        }
    }
}
