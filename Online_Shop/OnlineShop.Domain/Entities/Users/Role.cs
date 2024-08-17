using OnlineShop.domain.Entities.Common;

namespace OnlineShop.domain.Entities.Users
{
    public class Role : BaseEntity
    {
        public long Id { get; set; }
        public string name { get; set; }

        public ICollection<UserInRole> UserInRoles { get; set; }
    }
}
