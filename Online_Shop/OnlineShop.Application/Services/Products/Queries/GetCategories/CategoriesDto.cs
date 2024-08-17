namespace OnlineShop.Application.Services.Products.Queries.GetCategories
{
    public class CategoriesDto
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public bool HasChid { get; set; }
        public ParentCategoriesDto Parent { get; set; }
    }

}
