using Microsoft.EntityFrameworkCore;
using DataAcsessLayer.Concrete.Context;
using BusiniessLayer.Abstract;
using BusiniessLayer.Concrete;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Repositories;
var builder = WebApplication.CreateBuilder(args);

// appsettings.json'daki connection string'i oku
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i servislere ekle
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));



builder.Services.AddScoped<ICategoryDal, CategoryRepositories>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Test}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
