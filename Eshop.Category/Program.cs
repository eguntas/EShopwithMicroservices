using Eshop.Category.Services.CategoryServices;
using Eshop.Category.Services.ProductDetailDetailServices;
using Eshop.Category.Services.ProductImageServices;
using Eshop.Category.Services.ProductServices;
using Eshop.Category.Settings;
using Eshop.ProductDetail.Services.ProductDetailServices;
using Microsoft.Extensions.Options;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<ICategoryService , CategoryService>();
builder.Services.AddScoped<IProductService , ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();  
builder.Services.AddScoped<IProductImageService, ProductImageService>();


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

app.UseAuthorization();

app.MapControllers();

app.Run();
