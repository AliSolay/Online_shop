using OnlineShop.Application.Services.common.Querry.GetCategory;
using OnlineShop.Application.Services.common.Querry.GetHomePage;
using OnlineShop.Application.Services.common.Querry.GetMenu;
using OnlineShop.Application.Services.common.Querry.GetSliderList;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface ICommonFacad
    {
        IGetMenuItemService GetMenuItemService { get; }
        IGetCategoryService GetCategoryService { get; }
        IGetSliderListService GetSliderListService { get; }
        IGetHomePageImageService GetHomePageImageService { get; }
        //IGetSliderAdminService GetSliderAdminService { get; }
        //IAddNewSliderService AddNewSliderService { get; }
    }
}
