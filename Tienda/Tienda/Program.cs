using Microsoft.EntityFrameworkCore;
using Tienda.Models;
using Tienda.Models.Context;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ArticuloContext>(opcion =>
{
    opcion.UseSqlServer(builder.Configuration.GetConnectionString("ConexionBD"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Articulos}/{action=Index}/{id?}");

app.Run();
