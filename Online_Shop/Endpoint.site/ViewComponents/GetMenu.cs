using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;

namespace Endpoint.site.ViewComponents
{
    public class GetMenu : ViewComponent
    {
        private readonly ICommonFacad _commonFacad;
        public GetMenu(ICommonFacad commonFacad)
        {
            _commonFacad = commonFacad;
        }

        public IViewComponentResult Invoke()
        {
            var resultMenu = _commonFacad.GetMenuItemService.Execute();
            return View(viewName:"GetMenu",resultMenu.Data);
        }

    }
}
