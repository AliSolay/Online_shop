using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.HomePages.AddHomePageImage;
using OnlineShop.Application.Services.HomePages.Command.EditHomePageImage;
using OnlineShop.Common.Common.HomePage;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class HomePageController : Controller
    {
        private readonly IAddHomePageImageService _addHomePageImageService;
        private readonly ICommonFacad _commonFacad;
        private readonly IHomePageFacad _homePageFacad;
        public HomePageController(IAddHomePageImageService addHomePageImageService,ICommonFacad commonFacad, IHomePageFacad homePageFacad)
        {
            _addHomePageImageService = addHomePageImageService;
            _commonFacad = commonFacad;
            _homePageFacad = homePageFacad;
        }
        public IActionResult Index()
        {
            var homepage = _commonFacad.GetHomePageImageService.Execute().Data;
            return View(homepage);
        }
        public IActionResult Edit(long id , string src, string link,ImageLocation imageLocation)
        {

            var homepage = _homePageFacad.EditHomePageImageService.Execute(new RequestHomePageDto
            {
                Id = id,
                Link = link,
                Src = src,
                Location = imageLocation,
            });
            return Json(homepage);
        }

        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(IFormFile file, string link,ImageLocation imageLocation)
        {
            _addHomePageImageService.Execute(new AddHomePageImageDto
            {
                File = file,
                Link = link,
                ImageLocation = imageLocation
            });
            return View();
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            var homepage = _homePageFacad.RemoveHomePageService.Execute(Id);
            return Json(homepage);
        }
    }
}
