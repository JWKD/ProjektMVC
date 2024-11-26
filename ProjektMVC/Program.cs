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
        options.LoginPath = "/customers/login";  // �cie�ka logowania, je�li nie jeste� zalogowany
        options.AccessDeniedPath = "/";  // �cie�ka, je�li dost�p jest zabroniony
    });

// Dodaj autoryzacj�
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

app.UseAuthentication();  // Umo�liwia obs�ug� logowania i autoryzacji

app.UseAuthorization();
// W��czenie uwierzytelniania i autoryzacji


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
