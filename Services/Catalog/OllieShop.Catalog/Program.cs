using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Options;
using OllieShop.Catalog.Services.AboutServices;
using OllieShop.Catalog.Services.CarouselServices;
using OllieShop.Catalog.Services.CategoryServices;
using OllieShop.Catalog.Services.ContactServices;
using OllieShop.Catalog.Services.FeatureServices;
using OllieShop.Catalog.Services.OfferServices;
using OllieShop.Catalog.Services.ProductDetailService;
using OllieShop.Catalog.Services.ProductDetailServices;
using OllieShop.Catalog.Services.ProductImageService;
using OllieShop.Catalog.Services.ProductImageServices;
using OllieShop.Catalog.Services.ProductService;
using OllieShop.Catalog.Services.ProductServices;
using OllieShop.Catalog.Services.VendorServices;
using OllieShop.Catalog.Settings;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCatalog";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IProductDetailService, ProductDetailService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<ICarouselService, CarouselService>();
builder.Services.AddScoped<IOfferService, OfferService>();
builder.Services.AddScoped<IFeatureService, FeatureService>();
builder.Services.AddScoped<IVendorService, VendorService>();
builder.Services.AddScoped<IAboutService, AboutService>();
builder.Services.AddScoped<IContactService, ContactService>();

builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));
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
