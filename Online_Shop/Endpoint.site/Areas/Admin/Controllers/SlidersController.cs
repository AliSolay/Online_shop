using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.HomePages.Sliders.Command.AddNewSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Command.EditSlider;

namespace Endpoint.site.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SlidersController : Controller
    {
        private readonly IAddNewSliderService _addNewSliderService;
        private readonly ISliderFacad _sliderFacad;
        public SlidersController(IAddNewSliderService addNewSliderService, ISliderFacad sliderFacad)
        {
            _addNewSliderService = addNewSliderService;
            _sliderFacad = sliderFacad;
        }

        public IActionResult Index()
        {
            var slider = _sliderFacad.GetSliderAdminService.Execute().Data;
            return View(slider);
        }

        [HttpPost]
        public IActionResult Delete(long Id)
        {
            return Json(_sliderFacad.RemoveSliderSevice.Execute(Id));
        }

        [HttpPost]
        public IActionResult Edit(long SlId, string Src, string Link)
        {
            return Json(_sliderFacad.EditSliderSevice.Execute(new RequestEditSliderDto
            {
                Id = SlId,
                Src = Src,
                Link = Link,
            }));
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(IFormFile file, string link)
        {
            _addNewSliderService.Execute(file, link);
            return View();
        }
    }
}
