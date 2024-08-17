using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class PayController : Controller
    {
        private readonly IPayFacad _payFacad;
        public PayController(IPayFacad payFacad)
        {
            _payFacad = payFacad;
        }
        public IActionResult Index(int page, int pageSize)
        {
            return View(_payFacad.GetRequestPayAdminService.Execute(pageSize,page).Data);
        }
    }
}
