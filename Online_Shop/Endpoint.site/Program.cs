using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using OnlineShop.application.Intefaces.Context;
using OnlineShop.Application.Facad;
using OnlineShop.Application.Intefaces.Facad;
using OnlineShop.Application.Services.Carts;
using OnlineShop.Application.Services.HomePages.AddHomePageImage;
using OnlineShop.Application.Services.HomePages.Sliders.Command.AddNewSlider;
using OnlineShop.common.Role;
using OnlineShop.presistence.Context;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<IDataBaseContext, DataBaseContext>();
builder.Services.AddScoped<IUsersFacad, UsersFacad>();
builder.Services.AddScoped<IProductFacad, ProductFacad>();
builder.Services.AddScoped<ICommonFacad, CommonFacad>();
builder.Services.AddScoped<IAuthenticationFacad, AuthenticationFacad>();
builder.Services.AddScoped<ISliderFacad, SliderFacad>();
builder.Services.AddScoped<IPayFacad, PayFacad>();
builder.Services.AddScoped<IOrderFacad, OrderFacad>();
builder.Services.AddScoped<IHomePageFacad, HomePageFacad>();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddScoped<IAddNewSliderService, AddNewSliderService>();
builder.Services.AddScoped<IAddHomePageImageService, AddHomePageImageService>();



string conectionString = @"Data Source =DESKTOP-KD8IE0K\SQLSERVER ;Initial Catalog =OnlineShopDB ; integrated security=true";
builder.Services.AddEntityFrameworkSqlServer().AddDbContext<DataBaseContext>(option => option.UseSqlServer(conectionString));
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy(UserRoles.Admin, policy => policy.RequireRole(UserRoles.Admin));
    options.AddPolicy(UserRoles.Customer, policy => policy.RequireRole(UserRoles.Customer));
    options.AddPolicy(UserRoles.Oprator, policy => policy.RequireRole(UserRoles.Oprator));
});

builder.Services.AddAuthentication(options =>
{
    options.DefaultSignInScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultAuthenticateScheme = CookieAuthenticationDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = CookieAuthenticationDefaults.AuthenticationScheme;
}).AddCookie(options =>
{
    options.LoginPath = new PathString("/Authentication/Signin");
    options.ExpireTimeSpan = TimeSpan.FromMinutes(5.0);
    options.AccessDeniedPath = new PathString("/Authentication/AccessDenied");
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.MapControllerRoute(
                   name: "areas",
                    pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}");

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");


app.Run();
