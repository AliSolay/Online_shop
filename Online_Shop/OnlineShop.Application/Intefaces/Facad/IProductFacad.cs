using OnlineShop.Application.Services.Products.Command.AddNewCategory;
using OnlineShop.Application.Services.Products.Command.AddNewProductFolder;
using OnlineShop.Application.Services.Products.Queries.GetAllCategories;
using OnlineShop.Application.Services.Products.Queries.GetCategories;
using OnlineShop.Application.Services.Products.Queries.GetProdctsDetailsForAdmin;
using OnlineShop.Application.Services.Products.Queries.GetProductDetailForSite;
using OnlineShop.Application.Services.Products.Queries.GetProductsForAdmin;
using OnlineShop.Application.Services.Products.Queries.GetProductsForSite;

namespace OnlineShop.Application.Intefaces.Facad
{
    public interface IProductFacad
    {
        AddNewCategoryService AddNewCategoryService { get; }
        IGetCategoriesService GetCategoriesService { get; }
        IAddNewProductService AddNewProductServices { get; }
        IGetAllCategoriesService GetAllCategoriesService { get; }
        IGetProductForAdminService GetProductForAdminService { get; }
        IGetProductsDetailForAdminService GetProductsDetailForAdminService { get; }
        IGetProductForSiteService GetProductForSiteService { get; }
        IGetProductDetailForSiteService GetProductDetailForSiteService { get; }
    }
}
