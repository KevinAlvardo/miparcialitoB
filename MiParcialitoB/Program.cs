using Microsoft.EntityFrameworkCore;
using AM101820.Entities;

var builder = WebApplication.CreateBuilder(args);

// Configurar el servicio del DbContext con MySQL
builder.Services.AddDbContext<AM101820Context>(options =>
    options.UseMySql(
        "Server=qa.negociostecnologicos.net;Database=AM101820;User=desarrolloWebUfg;Password=<BTj$jrrLV2~-4Yp1vT-;Port=3306;",
        new MySqlServerVersion(new Version(8, 0, 21)) // Ajusta la versión si es necesario
    )
);

// Agregar controladores con vistas
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configurar la tubería de middleware
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
