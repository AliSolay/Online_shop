using Microsoft.AspNetCore.Hosting;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.common.Querry.GetCategory;
using OnlineShop.Application.Services.common.Querry.GetHomePage;
using OnlineShop.Application.Services.common.Querry.GetMenu;
using OnlineShop.Application.Services.common.Querry.GetSliderList;
using OnlineShop.Application.Services.HomePages.Sliders;

namespace OnlineShop.Application.Facad
{
    public class CommonFacad : ICommonFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public CommonFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private IGetMenuItemService _getMenuItemService;
        public IGetMenuItemService GetMenuItemService
        {
            get
            {
                return _getMenuItemService = _getMenuItemService ?? new GetMenuItemService(_context);
            }
        }

        private IGetCategoryService _getCategoryService;
        public IGetCategoryService GetCategoryService
        {
            get
            {
                return _getCategoryService = _getCategoryService ?? new GetCategoryService(_context);
            }
        }

        /////////
        //private IGetSliderAdminService _getSliderAdminService;
        //public IGetSliderAdminService GetSliderAdminService
        //{
        //    get
        //    {
        //        return _getSliderAdminService = _getSliderAdminService ?? new GetSliderAdminService(_context);
        //    }
        //}

        ///////////
        //private IAddNewSliderService _addNewSliderService;
        //public IAddNewSliderService AddNewSliderService
        //{
        //    get
        //    {
        //        return _addNewSliderService = _addNewSliderService ?? new AddNewSliderService(_environment , _context);
        //    }
        //}

        /////////

        private IGetSliderListService _getSliderListService;
        public IGetSliderListService GetSliderListService
        {
            get
            {
                return _getSliderListService = _getSliderListService ?? new GetSliderListService(_context);
            }
        }


        private IGetHomePageImageService _getHomePageImageService;
        public IGetHomePageImageService GetHomePageImageService
        {
            get
            {
                return _getHomePageImageService = _getHomePageImageService ?? new GetHomePageImageService(_context);
            }
        }


    }
}
