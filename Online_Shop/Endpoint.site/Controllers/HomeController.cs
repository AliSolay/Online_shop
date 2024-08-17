using Endpoint.site.Models;
using Endpoint.site.Models.ViewModels.HomePages;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using System.Diagnostics;

namespace Endpoint.site.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICommonFacad _commonFacad;

        public HomeController(ILogger<HomeController> logger,ICommonFacad commonFacad)
        {
            _logger = logger;
            _commonFacad = commonFacad;
        }

        public IActionResult Index()
        {
            HomePageViewModel homePage = new HomePageViewModel()
            {
                Sliders = _commonFacad.GetSliderListService.Execute().Data,
                PageImages = _commonFacad.GetHomePageImageService.Execute().Data,
                
            };
            return View(homePage);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}