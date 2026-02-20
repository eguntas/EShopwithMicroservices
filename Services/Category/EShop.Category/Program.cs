using Eshop.Category.Services.CategoryServices;
using Eshop.Category.Services.ProductDetailDetailServices;
using Eshop.Category.Services.ProductImageServices;
using Eshop.Category.Services.ProductServices;
using Eshop.Category.Settings;
using Eshop.ProductDetail.Services.ProductDetailServices;
using EShop.Brand.Services.BrandServices;
using EShop.Category.Services.AboutServices;
using EShop.Category.Services.BrandServices;
using EShop.Category.Services.ContactServices;
using EShop.Category.Services.FeatureServices;
using EShop.Category.Services.FeatureSliderServices;
using EShop.Category.Services.OfferDiscountServices;
using EShop.Category.Services.SpecialOfferServices;
using EShop.Category.Services.StatisticServices;
using EShop.OfferDiscount.Services.OfferDiscountServices;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
{
    options.Authority = builder.Configuration["IdentityServerURL"];
    options.Audience = "ResourceCatalog";
    options.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();  
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IFeatureSliderService, FeatureSliderService>();
builder.Services.AddScoped<ISpecialOfferService, SpecialOfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IOfferDiscountService, OfferDiscountService>();
builder.Services.AddScoped<IBrandService, BrandService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();
builder.Services.AddScoped<IStatisticService, StatisticService>();


builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSetting"));
builder.Services.AddScoped<IDatabaseSettings>(sp =>
{
    return sp.GetRequiredService<IOptions<DatabaseSettings>>().Value;
});

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
