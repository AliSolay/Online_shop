using OnlineShop.Application.Services.HomePages.Sliders.Command.AddNewSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Command.EditSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Command.RemoveSlider;
using OnlineShop.Application.Services.HomePages.Sliders.Querry.GetSliderAdmin;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface ISliderFacad
    {
        IRemoveSliderSevice RemoveSliderSevice { get; }
        IEditSliderSevice EditSliderSevice { get; }
        IGetSliderAdminService GetSliderAdminService { get; }
        //IAddNewSliderService AddNewSliderService { get; }
    }
}
