using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register ShopDbContext
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=ProjektMVC;Trusted_Connection=True;"));

// Konfiguracja uwierzytelniania
// Dodanie sesji
builder.Services.AddSession(options =>
{
    options.IdleTimeout = TimeSpan.FromMinutes(30); // Czas wygasania sesji
});

// Dodanie autoryzacji (i konfiguracja uwierzytelniania)
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(options =>
    {
        options.LoginPath = "/customers/login";  // Œcie¿ka logowania, jeœli nie jesteœ zalogowany
        options.AccessDeniedPath = "/";  // Œcie¿ka, jeœli dostêp jest zabroniony
    });

// Dodaj autoryzacjê
builder.Services.AddAuthorization();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseSession();

app.UseAuthentication();  // Umo¿liwia obs³ugê logowania i autoryzacji

app.UseAuthorization();
// W³¹czenie uwierzytelniania i autoryzacji


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
