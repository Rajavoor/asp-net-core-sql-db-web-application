using DotnetMirror.ASPNETCORESQLDBWebApplication.Data;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddScoped<IDAL, DAL>();

var app = builder.Build();

var connectionString = builder.Configuration.GetConnectionString("AzureSQLServerConnection");

services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));


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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.MapControllerRoute(
    name: "cert",
    pattern: "{controller=Cert}/{action=Index}/{id?}");

app.Run();
