using System.Reflection;
using FoodDelivery.Data;
using FoodDelivery.Repository;
using FoodDelivery.Service;
using FoodDelivery.Service.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "Food Delivery API",
        Description = "An ASP.NET Core Web API for food delivery",
        Contact = new OpenApiContact
        {
            Name = "Grody",
            Url = new Uri("https://t.me/GroD_off")
        },
    });
});

builder.Services.AddDbContext<AppDbContext>(
    opts =>
    {
        var connectionString = builder.Configuration.GetConnectionString("PostgreConnection");
        opts.UseNpgsql(connectionString);
    });

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IAddressService, AddressService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IUserService, UserService>();


var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();