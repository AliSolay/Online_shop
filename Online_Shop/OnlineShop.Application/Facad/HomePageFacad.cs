using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.HomePages.Command.EditHomePageImage;
using OnlineShop.Application.Services.HomePages.Command.RemoveHomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Facad
{
    public class HomePageFacad : IHomePageFacad
    {
        private readonly IDataBaseContext _context;
        public HomePageFacad(IDataBaseContext context)
        {
            _context = context;
        }

        private IRemoveHomePageService _removeHomePageService;
        public IRemoveHomePageService RemoveHomePageService
        {
            get
            {
                return _removeHomePageService = _removeHomePageService ?? new RemoveHomePageService(_context);
            }
        }

        private IEditHomePageImageService _editHomePageImageService;
        public IEditHomePageImageService EditHomePageImageService
        {
            get
            {
                return _editHomePageImageService = _editHomePageImageService ?? new EditHomePageImageService(_context);
            }
        }
    }
}
