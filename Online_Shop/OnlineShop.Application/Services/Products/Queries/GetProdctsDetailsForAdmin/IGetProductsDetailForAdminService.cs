using Microsoft.EntityFrameworkCore;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;
using OnlineShop.domain.Entities.Products;

namespace OnlineShop.Application.Services.Products.Queries.GetProdctsDetailsForAdmin
{
    public interface IGetProductsDetailForAdminService
    {
        ResultDto<ProductsDetailForAdminDto> Execute(long Id);
    }

    public class GetProductsDetailForAdminService : IGetProductsDetailForAdminService
    {
        private readonly IDataBaseContext _context;
        public GetProductsDetailForAdminService(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<ProductsDetailForAdminDto> Execute(long Id)
        {
            var prduct = _context.Products
                .Include(p => p.Category)
                .ThenInclude(p => p.ParentCategory)
                .Include(p => p.ProductFeatures)
                .Include(p => p.ProductImage)
                .Where(p => p.Id == Id)
                .FirstOrDefault();
            return new ResultDto<ProductsDetailForAdminDto>
            {
                Data = new ProductsDetailForAdminDto
                {
                    Id = Id,
                    Name = prduct.Name,
                    Price = prduct.Price,
                    Brand = prduct.Brand,
                    Description = prduct.Description,
                    Inventory = prduct.Inventory,
                    Displayed = prduct.Displayed,
                    Category = GetCategory(prduct.Category),
                    Features = prduct.ProductFeatures.ToList().Select(p => new ProductDetailFeatureDto
                    {
                        Id = p.Id,
                        DisplayName = p.DisplayName,
                        Value = p.Value,
                    }).ToList(),
                    Images = prduct.ProductImage.ToList().Select(p => new ProductDetailImagesDto
                    {
                        Id = p.Id,
                        Src = p.Src,
                    }).ToList(),
                }
            };

        }

        private string GetCategory(Category category)
        {
            string result = category.ParentCategory != null ? $"{category.ParentCategory.Name} - " : "";
            return result += category.Name;
        }
    }

    public class ProductsDetailForAdminDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public string Brand { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
        public int Inventory { get; set; }
        public bool Displayed { get; set; }
        public List<ProductDetailFeatureDto> Features { get; set; }
        public List<ProductDetailImagesDto> Images { get; set; }
    }

    public class ProductDetailFeatureDto
    {
        public long Id { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }

    public class ProductDetailImagesDto
    {
        public long Id { get; set; }
        public string Src { get; set; }
    }
}
