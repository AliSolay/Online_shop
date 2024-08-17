using OnlineShop.Common.Common.HomePage;
using OnlineShop.domain.Entities.Common;


namespace OnlineShop.Domain.Entities.HomePages
{
    public class HomePageImage : BaseEntity
    {
        public string Src { get; set; }
        public string Link { get; set; }
        public ImageLocation ImageLocation { get; set; }
    }
    
}
