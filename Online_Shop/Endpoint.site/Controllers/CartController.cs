using Endpoint.site.Utilities;
using EndPoint.Site.Utilities;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Services.Carts;

namespace Endpoint.site.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;
        private readonly CookiesManeger cookiesManeger;
        public CartController(ICartService cartService)
        {
            _cartService = cartService;
            cookiesManeger = new CookiesManeger();
        }
        public IActionResult Index()
        {

            var userId = ClaimUtility.GetUserId(User);
            var resultGet = _cartService.GetMyCart(cookiesManeger.GetBrowserId(HttpContext),userId);
            return View(resultGet.Data);
        }

        public IActionResult AddCart(long ProductId)
        {
            var resultAdd = _cartService.AddCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }

        public IActionResult Remove(long ProductId)
        {
            var resultDel = _cartService.RemoveCart(ProductId, cookiesManeger.GetBrowserId(HttpContext));
            return RedirectToAction("Index");
        }



    }
}
