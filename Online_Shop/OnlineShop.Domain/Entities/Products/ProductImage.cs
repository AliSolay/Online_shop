using OnlineShop.domain.Entities.Common;

namespace OnlineShop.domain.Entities.Products
{
    public class ProductImage : BaseEntity
    {
        public long ProductId { get; set; }
        public string Src { get; set; }
        public virtual Product Product { get; set; }
    }

}
