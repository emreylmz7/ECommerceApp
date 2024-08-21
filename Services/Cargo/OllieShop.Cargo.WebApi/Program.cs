using Microsoft.AspNetCore.Authentication.JwtBearer;
using OllieShop.Cargo.BusinessLayer.Abstarct;
using OllieShop.Cargo.BusinessLayer.Concrete;
using OllieShop.Cargo.DataAccessLayer.Abstract;
using OllieShop.Cargo.DataAccessLayer.Concrete;
using OllieShop.Cargo.DataAccessLayer.EntityFramework;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
{
    opt.Authority = builder.Configuration["IdentityServerUrl"];
    opt.Audience = "ResourceCargo";
    opt.RequireHttpsMetadata = false;
});

builder.Services.AddDbContext<CargoContext>();
builder.Services.AddHttpContextAccessor();

builder.Services.AddScoped<ICargoDetailDal,EfCargoDetailDal>();
builder.Services.AddScoped<ICargoDal,EfCargoDal>();

builder.Services.AddScoped<ICargoDetailService, CargoDetailManager>();
builder.Services.AddScoped<ICargoService, CargoManager>();

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
