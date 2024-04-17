using DirtX.Core.Interfaces;
using DirtX.Core.Services;
using DirtX.Infrastructure.Data;
using DirtX.Infrastructure.Data.Models.Users;
using DirtX.Scraper.Data;
using DirtX.Scraper.Shared;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.FileProviders;
using static DirtX.Infrastructure.Data.Seeders.UserSeeder;

var builder = WebApplication.CreateBuilder(args);

// DATABASE SERVICE
string defaultConnection = builder.Configuration.GetConnectionString("DefaultConnection");
string scraperConnection = builder.Configuration.GetConnectionString("ScraperConnection");

builder.Services.AddDbContext<ApplicationDbContext>(options => { options.UseSqlServer(defaultConnection); });
builder.Services.AddDbContext<ScraperDbContext>(options => { options.UseSqlServer(scraperConnection); });

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

builder.Services.AddControllersWithViews()
    .AddMvcOptions(options =>
    {
        options.Filters.Add<AutoValidateAntiforgeryTokenAttribute>();
    });

// SESSION
builder.Services.AddSession(options =>
{
    options.Cookie.Name = ".DirtX.Session";
    options.IdleTimeout = TimeSpan.FromMinutes(30);
});

// SERVICES
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IMotorcycleService, MotorcycleService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<ScraperSettings>();
builder.Services.AddTransient<IScraperService, ScraperService>();

var app = builder.Build();

// SEED USERS
using (IServiceScope scope = app.Services.CreateScope())
{
    IServiceProvider services = scope.ServiceProvider;
    //try
    //{
        var userManager = services.GetRequiredService<UserManager<AppUser>>();
        var roleManager = services.GetRequiredService<RoleManager<IdentityRole>>();
        await SeedUsersAsync(userManager, roleManager);
    //}
    //catch (Exception)
    //{
    //    throw new ApplicationException();
    //}
}

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseMigrationsEndPoint();
}
else
{
    app.UseExceptionHandler("/Home/Error?statusCode=500");
    app.UseStatusCodePagesWithRedirects("/Home/Error?statusCode={0}");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseEndpoints(endpoints =>
{
    endpoints.MapControllerRoute(
      name: "Admin",
      pattern: "{area:exists}/{controller=Home}/{action=Index}/{id?}"
    );

    endpoints.MapControllerRoute(
   name: "default",
   pattern: "{controller=Home}/{action=Index}/{id?}");
});

app.MapRazorPages();

app.Run();