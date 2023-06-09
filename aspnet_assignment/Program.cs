using aspnet_assignment.Contexts;
using aspnet_assignment.Helpers.Repositories;
using aspnet_assignment.Helpers.Services;
using aspnet_assignment.Models.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<IdentityContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("IdentityDB")));
builder.Services.AddDbContext<DataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("ProductDB")));
builder.Services.AddDbContext<CommentDataContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("CommentDB")));
builder.Services.AddScoped<AddressService>();
builder.Services.AddScoped<UserService>();
builder.Services.AddScoped<StockService>();
builder.Services.AddScoped<ImageService>();
builder.Services.AddScoped<CommentService>();
builder.Services.AddScoped<ProductCategoryService>();
builder.Services.AddScoped<CategoryService>();
builder.Services.AddScoped<ProductService>();
builder.Services.AddScoped<AddressRepository>();
builder.Services.AddScoped<AuthenticationService>();
builder.Services.AddScoped<UserAddressRepository>();

builder.Services.AddIdentity<CustomUser, IdentityRole>(x =>
{
    x.SignIn.RequireConfirmedAccount = false;
    x.Password.RequiredLength = 8;
    x.User.RequireUniqueEmail = true;
}).AddEntityFrameworkStores<IdentityContext>();

var app = builder.Build();


app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

using (var scope = app.Services.CreateScope())
{
    var roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();

    var roles = new[] { "Admin", "User" };

    foreach(var role in roles)
    {
        if(!await roleManager.RoleExistsAsync(role))
        {
            await roleManager.CreateAsync(new IdentityRole(role));
        }
    }
}

using (var scope = app.Services.CreateScope())
{
    var stockService = scope.ServiceProvider.GetRequiredService<StockService>();

    await stockService.PopulateStockAsync();
}

using (var scope = app.Services.CreateScope())
{
    var categoryService = scope.ServiceProvider.GetRequiredService<CategoryService>();

    await categoryService.PopulateCategoriesAsync();
}

app.Run();
