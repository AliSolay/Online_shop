using Microsoft.EntityFrameworkCore;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Products.Queries.GetCategories
{
    public class GetCategoriesServices : IGetCategoriesService
    {
        private readonly IDataBaseContext _context;
        public GetCategoriesServices(IDataBaseContext context)
        {
            _context = context;
        }
        public ResultDto<List<CategoriesDto>> Execute(long? ParentId)
        {
            var categories = _context.Categories
                .Include(c => c.ParentCategory)
                .Include(c => c.ChildCategories)
                .Where(c => c.ParentCategoryId == ParentId)
                .ToList()
                .Select(c => new CategoriesDto
                {
                    Id = c.Id,
                    Name = c.Name,
                    Parent = c.ParentCategory != null ? new
                    ParentCategoriesDto
                    {
                        Id = c.ParentCategory.Id,
                        name = c.ParentCategory.Name,
                    } : null,
                    HasChid = c.ChildCategories.Count() > 0 ? true : false,
                }).ToList();

            return new ResultDto<List<CategoriesDto>>
            {
                Data = categories,
                IsSuccess = true,
                Message = "عملیات موفقیت امیز"
            };
        }
    }

}
