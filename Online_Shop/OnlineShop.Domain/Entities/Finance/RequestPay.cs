using OnlineShop.domain.Entities.Common;
using OnlineShop.domain.Entities.Users;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.Domain.Entities.Finance
{
    public class RequestPay : BaseEntity
    {
        public Guid Guid { get; set; }
        public virtual User User { get; set; }
        public long UserId { get; set; }
        public int Amount { get; set; }
        public bool IsPay { get; set; }
        public DateTime? PayDate { get; set; }
        public string Authority { get; set; } = "";
        public long RefId { get; set; } = 0;
        public virtual ICollection<Order> Orders { get; set; }
    }
}
