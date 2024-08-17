using OnlineShop.Common.Dto;

namespace OnlineShop.Application.Services.Products.Command.AddNewCategory
{
    public interface IAddNewCategoryService
    {
        ResultDto Execute(long? ParentId, string Name);
    }
}
