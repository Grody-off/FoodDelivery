using System.Net;
using System.Reflection;
using FoodDelivery.Data;
using FoodDelivery.Repository;
using FoodDelivery.Service;
using FoodDelivery.Service.Interfaces;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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

// var port = Environment.GetEnvironmentVariable("PORT") ?? "8080";
// var url = $"http://0.0.0.0:{port}";
// var target = Environment.GetEnvironmentVariable("TARGET") ?? "World";

var app = builder.Build();

// Configure the HTTP request pipeline.

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

//app.UseRouting();
app.UseAuthorization();

// app.UseEndpoints(endpoints =>
// {
//     endpoints.MapControllers();
// });
app.MapControllers();

//app.MapGet("/", () => $"Hello {target}!");
// app.Run(url);
app.Run();