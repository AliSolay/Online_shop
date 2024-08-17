using Microsoft.AspNetCore.Hosting;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.HomePages.Sliders.Command.AddNewSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Command.EditSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Command.RemoveSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Querry.GetSliderAdmin;

namespace OnlineShop.Application.Facad
{
    public class SliderFacad : ISliderFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public SliderFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IRemoveSliderSevice _removeSliderSevice;
        public IRemoveSliderSevice RemoveSliderSevice
        {
            get
            {
                return _removeSliderSevice = _removeSliderSevice ?? new RemoveSliderSevice(_context);
            }
        }

        private IEditSliderSevice _editSliderSevice;
        public IEditSliderSevice EditSliderSevice
        {
            get
            {
                return _editSliderSevice = _editSliderSevice ?? new EditSliderSevice(_context);
            }
        }

        private IGetSliderAdminService _getSliderAdminService;
        public IGetSliderAdminService GetSliderAdminService
        {
            get
            {
                return _getSliderAdminService = _getSliderAdminService ?? new GetSliderAdminService(_context);
            }
        }

        //private IAddNewSliderService _addNewSliderService;
        //public IAddNewSliderService AddNewSliderService
        //{
        //    get
        //    {
        //        return _addNewSliderService = _addNewSliderService ?? new AddNewSliderService(_context, _environment);
        //    }
        //}
    }
}
