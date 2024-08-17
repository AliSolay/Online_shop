using OnlineShop.Application.Services.HomePages.Command.EditHomePageImage;
using OnlineShop.Application.Services.HomePages.Command.RemoveHomePage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface IHomePageFacad
    {
        IRemoveHomePageService RemoveHomePageService { get; }
        IEditHomePageImageService EditHomePageImageService { get; }
    }
}
