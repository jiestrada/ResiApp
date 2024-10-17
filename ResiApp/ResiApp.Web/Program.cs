using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.EntityFrameworkCore;
using ResiApp.Services.Data;
using ResiApp.Services.Implementations;
using ResiApp.Services.Interfaces;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews().AddXmlSerializerFormatters();

builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme).
    AddCookie(options =>
    {
        options.LoginPath = "/Login";
        options.Cookie.Name = "j13h3w-r3s1499-g3atr41r3g";
    });

builder.Services.AddDbContext<ResiAppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("ConnResi")));

builder.Services.AddScoped<IUsuarioService, UsuarioService>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    app.UseStatusCodePagesWithReExecute("/NotFound", "?code={0}");
}

var cultureInfo = new CultureInfo("es-MX");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();



app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.UseStatusCodePagesWithReExecute("/NotFound");

app.Run();
