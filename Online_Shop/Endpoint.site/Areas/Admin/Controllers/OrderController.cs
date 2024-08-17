using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Domain.Entities.Orders;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class OrderController : Controller
    {
        private readonly IOrderFacad _orderFacad;
        public OrderController(IOrderFacad orderFacad)
        {
            _orderFacad = orderFacad;
        }
        public IActionResult Index(OrderState orderState)
        {
            return View(_orderFacad.GetOrdersForAdminService.Execute(orderState).Data);
        }
    }
}
