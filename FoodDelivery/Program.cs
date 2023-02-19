using System.Net;
using FoodDelivery.Data;
using FoodDelivery.Repository;
using FoodDelivery.Service;
using FoodDelivery.Service.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.Configure<ForwardedHeadersOptions>(options =>
{
    options.KnownProxies.Add(IPAddress.Parse("10.186.0.10 "));
});

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
builder.Services.AddScoped<INotificationService, NotificationService>();

builder.Services.AddHostedService<MessageBgJob>();

var app = builder.Build();

app.UseSwagger(c =>
{
    c.SerializeAsV2 = true;
});
app.UseSwaggerUI();
app.UseHttpsRedirection();
app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.UseAuthorization();
app.MapControllers();
app.Run();