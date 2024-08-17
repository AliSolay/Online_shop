using OnlineShop.domain.Entities.Common;

namespace OnlineShop.domain.Entities.Products
{
    public class ProductFeatures : BaseEntity
    {
        public string DisplayName { get; set; }
        public string Value { get; set; }
        public virtual Product Product { get; set; }
        public long ProductId { get; set; }
    }

}
