using Microsoft.AspNetCore.Hosting;
using OnlineShop.Application.Services.Products.Command.AddNewCategory;
using OnlineShop.Application.Services.Products.Command.AddNewProductFolder;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Services.Products.Queries.GetAllCategories;
using OnlineShop.Application.Services.Products.Queries.GetCategories;
using OnlineShop.Application.Services.Products.Queries.GetProdctsDetailsForAdmin;
using OnlineShop.Application.Services.Products.Queries.GetProductDetailForSite;
using OnlineShop.Application.Services.Products.Queries.GetProductsForAdmin;
using OnlineShop.Application.Services.Products.Queries.GetProductsForSite;

namespace OnlineShop.Application.Facad
{
    public class ProductFacad : IProductFacad
    {
        private readonly IDataBaseContext _context;
        private readonly IHostingEnvironment _environment;
        public ProductFacad(IDataBaseContext context, IHostingEnvironment environment)
        {
            _context = context;
            _environment = environment;
        }

        private AddNewCategoryService _addNewCategory;
        public AddNewCategoryService AddNewCategoryService
        {
            get
            {
                return _addNewCategory = _addNewCategory ?? new AddNewCategoryService(_context);
            }
        }

        private IAddNewProductService _addNewProductServices;
        public IAddNewProductService AddNewProductServices
        {
            get
            {
                return _addNewProductServices = _addNewProductServices ?? new AddNewProductService(_context, _environment);
            }
        }


        private IGetCategoriesService _getCategoriesService;
        public IGetCategoriesService GetCategoriesService
        {
            get
            {
                return _getCategoriesService = _getCategoriesService ?? new GetCategoriesServices(_context);
            }
        }

        private IGetAllCategoriesService _getAllCategoriesService;
        public IGetAllCategoriesService GetAllCategoriesService
        {
            get
            {
                return _getAllCategoriesService = _getAllCategoriesService ?? new GetAllCategoriesService(_context);
            }
        }

        private IGetProductForAdminService _getProductForAdminService;
        public IGetProductForAdminService GetProductForAdminService
        {
            get
            {
                return _getProductForAdminService = _getProductForAdminService ?? new GetProductForAdminService(_context);
            }
        }

        private IGetProductsDetailForAdminService _getProductsDetailForAdminService;
        public IGetProductsDetailForAdminService GetProductsDetailForAdminService
        {
            get
            {
                return _getProductsDetailForAdminService = _getProductsDetailForAdminService ?? new GetProductsDetailForAdminService(_context);
            }
        }

        private IGetProductForSiteService _getProductForSiteService;
        public IGetProductForSiteService GetProductForSiteService
        {
            get
            {
                return _getProductForSiteService = _getProductForSiteService ?? new GetProductForSiteService(_context);
            }
        }

        private IGetProductDetailForSiteService _getProductDetailForSiteService;
        public IGetProductDetailForSiteService GetProductDetailForSiteService
        {
            get
            {
                return _getProductDetailForSiteService = _getProductDetailForSiteService ?? new GetProductDetailForSiteService(_context);
            }
        }



    }
}


