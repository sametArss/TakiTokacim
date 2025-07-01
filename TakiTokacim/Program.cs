using Microsoft.EntityFrameworkCore;
using DataAcsessLayer.Concrete.Context;
using BusiniessLayer.Abstract;
using BusiniessLayer.Concrete;
using DataAcsessLayer.Abstract;
using DataAcsessLayer.Concrete.Repositories;
using DataAcsessLayer.EntityFramework;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.Extensions.Options;
using System.Globalization;
using Microsoft.AspNetCore.Identity;
using EntitiyLayer.Models;
var builder = WebApplication.CreateBuilder(args);

// appsettings.json'daki connection string'i oku
string connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

// DbContext'i servislere ekle
builder.Services.AddDbContext<AppDbContext>(options =>
{
    options.UseSqlServer(connectionString);
    options.UseLazyLoadingProxies(false);
});

// Identity servislerini ekle
builder.Services.AddIdentity<User, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/Account/Login";
    options.AccessDeniedPath = "/Account/AccessDenied";
});

// Generic Repository
builder.Services.AddScoped(typeof(IGenericRepositoriesDal<>), typeof(GenericRepositoriesDal<>));

// Entity'ye özel DAL'lar
builder.Services.AddScoped<ICartDal, EfCartDal>();
builder.Services.AddScoped<IProductDal, EFProductDal>();
builder.Services.AddScoped<ICategoryDal, EFCategoryDal>();
builder.Services.AddScoped<ICartItemsDal, EFCartItemDal>();
builder.Services.AddScoped<ICityDal, EFCityDal>();
builder.Services.AddScoped<ICommentsDal, EFCommentsDal>();
builder.Services.AddScoped<IDistrictDal, EFDistrictDal>();
builder.Services.AddScoped<IOrderDal, EFOrderDal>();
builder.Services.AddScoped<IPaymentDal, EFPaymentDal>();
builder.Services.AddScoped<IPaymentTypeDal, EFPaymentTypeDal>();
builder.Services.AddScoped<IUserDal, EFUserDal>();
builder.Services.AddScoped<IUserAdressDal, EFUserAdressDal>();

// Service Katmanı
builder.Services.AddScoped<IProductService, ProductManager>();
builder.Services.AddScoped<ICategoryService, CategoryManager>();
builder.Services.AddScoped<ICommentService, CommentManager>();
builder.Services.AddScoped<IUserService, UserManager>();
builder.Services.AddScoped<ICityService,CityManager>();     
builder.Services.AddScoped<IDistrictService, DistrictManager>();
builder.Services.AddScoped<IAdressService, AdressManager>();
builder.Services.AddScoped<ICartService,CartManager>();
builder.Services.AddScoped<IPaymentService,PaymentsManager>();



var cultureInfo = new CultureInfo("tr-TR");
CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
CultureInfo.DefaultThreadCurrentUICulture = cultureInfo;

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

app.UseAuthentication();
app.UseAuthorization();

app.MapStaticAssets();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}")
    .WithStaticAssets();


app.Run();
