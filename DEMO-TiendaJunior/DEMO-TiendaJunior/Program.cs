using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Repositories.Categoria;
using DEMO_TiendaJunior.Repositories.Venta;
using DEMO_TiendaJunior.Repositories.Precios;
using DEMO_TiendaJunior.Repositories.Productos;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IVentaRepository, VentasRepository>();
builder.Services.AddScoped<IPreciosRepository, PreciosRepository>();
//
builder.Services.AddScoped<ICategoriaRepository,  CategoriaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();

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
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
