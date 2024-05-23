using DEMO_TiendaJunior.Data;
using DEMO_TiendaJunior.Repositories.Precios;
using DEMO_TiendaJunior.Repositories.Venta;
using DEMO_TiendaJunior.Repositories.Categoria;
using DEMO_TiendaJunior.Repositories.Productos;
using DEMO_TiendaJunior.Repositories.DetallesVentas;
using DEMO_TiendaJunior.Repositories.UsersInfo;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.a
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
builder.Services.AddScoped<IVentaRepository, VentasRepository>();
builder.Services.AddScoped<IPreciosRepository, PreciosRepository>();
builder.Services.AddScoped<ICategoriaRepository, CategoriaRepository>();
builder.Services.AddScoped<IProductoRepository, ProductoRepository>();
builder.Services.AddScoped<IDetalleRepository, DetalleRepository>();
builder.Services.AddScoped<IRolesRepository, RolesRepository>();
builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
builder.Services.AddScoped<ILoginRepository, LoginRepository>();

builder.Services.AddAuthentication("CookieAuth")
    .AddCookie("CookieAuth", options =>
    {
        options.LoginPath = "/Login/Login";
        options.AccessDeniedPath = "/LoginCredential/AccessDenied"; 
        options.Cookie.Name = "TiendaJuniorAPP";
    });

var app = builder.Build();

app.Use(async (context, next) =>
{
    context.Response.Headers["Cache-Control"] = "no-cache, no-store, must-revalidate";
    context.Response.Headers["Pragma"] = "no-cache";
    context.Response.Headers["Expires"] = "0";
    await next();
});

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
    pattern: "{controller=Login}/{action=Login}/{id?}");

app.Run();
