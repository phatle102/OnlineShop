using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.SqlServer;
using OnlineShop.Models;
using OnlineShop.Repository;
using OnlineShop.Data;
using OnlineShop.Areas.Identity.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


//Dependency Injection
builder.Services.AddDbContext<IflyShopContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("IflyshopDB"));
});

builder.Services.AddDbContext<OnlineShopDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("OnlineShopDB"));
});

builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = false)
    .AddRoles<IdentityRole>()
    .AddRoleManager<RoleManager<IdentityRole>>()
    .AddEntityFrameworkStores<OnlineShopDBContext>();



builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;

});
//DI
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IProductRepository, ProductRepository>();
//step 1
builder.Services.AddSession();
var app = builder.Build();
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
app.UseAuthorization();

//step 2
app.UseSession();
app.MapAreaControllerRoute(
    name: "MyAreas",
    areaName: "Admin",
    pattern: "Admin/{controller}/{action=Index}/{id?}",
    defaults: new { controller = "Dashboard", action = "Index" }
    );

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();
