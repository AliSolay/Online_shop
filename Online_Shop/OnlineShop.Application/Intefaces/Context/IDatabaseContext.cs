using Microsoft.EntityFrameworkCore;
using OnlineShop.domain.Entities.HomePages;
using OnlineShop.domain.Entities.Products;
using OnlineShop.domain.Entities.Users;
using OnlineShop.Domain.Entities.Cart;
using OnlineShop.Domain.Entities.Finance;
using OnlineShop.Domain.Entities.HomePages;
using OnlineShop.Domain.Entities.Orders;

namespace OnlineShop.application.Intefaces.Context
{
    public interface IDataBaseContext
    {
        DbSet<User> Users { get; set; }
        DbSet<Role> Roles { get; set; }
        DbSet<UserInRole> UserInRoles { get; set; }
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }
        DbSet<Slider> Sliders { get; set; }
        DbSet<ProductImage> ProductImages { get; set; }
        DbSet<ProductFeatures> ProductFeatures { get; set; }
        DbSet<HomePageImage> HomePageImages { get; set; }
        DbSet<Cart> Carts { get; set; }
        DbSet<CartItem> CartItems { get; set; }
        DbSet<RequestPay> RequestPays { get; set; }
        DbSet<Order> Orders { get; set; }
        DbSet<OrderDetail> OrderDetails { get; set; }

        int SaveChanges(bool acceptAllChangesOnSuccess);
        int SaveChanges();
        Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = new CancellationToken());
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken());

    }
}
