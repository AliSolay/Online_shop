using Endpoint.site.Utilities;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Services.Carts;

namespace Endpoint.site.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger _cookiesManeger;
        public Cart(ICartService cartService)
        {
            _cartService = cartService;
            _cookiesManeger = new CookiesManeger();
        }


        public IViewComponentResult Invoke()
        {
            var userId = ClaimUtility.GetUserId(HttpContext.User);
            return View(viewName: "Cart",_cartService.GetMyCart(_cookiesManeger.GetBrowserId(HttpContext),userId).Data);
        }
    }
}
