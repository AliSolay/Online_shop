using Endpoint.site.Utilities;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Orders.Querry.GetOrders;

namespace Endpoint.site.Controllers
{
    public class OrdersController : Controller
    {
        private readonly IOrderFacad _orderFacad;
        public OrdersController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }
        public IActionResult Index()
        {
            long userId = ClaimUtility.GetUserId(User).Value;
            return View(_orderFacad.GetOrderService.Execute(userId).Data);
        }
    }
}
