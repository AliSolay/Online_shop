using OnlineShop.domain.Entities.Common;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.domain.Entities.Users
{
    public class User : BaseEntity
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public bool IsActive { get; set; } 
        public string Password { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
        public virtual ICollection<Order> Orders { get; set; }
    }
}
