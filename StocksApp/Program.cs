using StocksApp;
using Services;
using ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Entities;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));
builder.Services.AddScoped<IStocksService, StocksService>();
builder.Services.AddSingleton<IFinnhubService, FinnhubService>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();
