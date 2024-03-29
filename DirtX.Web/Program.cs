using DirtX.Core.Interfaces;
using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using static DirtX.Infrastructure.Data.Seeders.UserSeeder;

var builder = WebApplication.CreateBuilder(args);

//DATABASE SERVICE
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(connectionString);
});

builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddDefaultIdentity<AppUser>(options =>
    {
        options.SignIn.RequireConfirmedAccount = false;

        options.Password.RequireLowercase = true;
        options.Password.RequireUppercase = true;
        options.Password.RequireNonAlphanumeric = false;
        options.Password.RequiredLength = 5;

        options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromSeconds(10);
    })
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>();

builder.Services.AddControllersWithViews();

//CUSTOM SERVICES
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();

var app = builder.Build();

//TRY TO SEED USERS
using (var scope = app.Services.CreateScope())
{
    var services = scope.ServiceProvider;
    try
    {
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await SeedUsersAsync(userManager, roleManager);
    }
    catch (Exception ex)
    {
        Console.WriteLine(ex.Message);
    }
}

if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapRazorPages();

app.Run();
