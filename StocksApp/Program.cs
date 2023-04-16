using StocksApp;
using Services;
using ServiceContracts;
using Microsoft.EntityFrameworkCore;
using Entities;
using Repositories;
using RepositoryContracts;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((HostBuilderContext ctx, IServiceProvider services, LoggerConfiguration LoggerConfiguration) => {
    LoggerConfiguration.ReadFrom.Configuration(ctx.Configuration);
    //LoggerConfiguration.ReadFrom.(ctx.Configuration);
    LoggerConfiguration.ReadFrom.Services(services);
}
);


builder.Services.AddControllersWithViews();
builder.Services.Configure<TradingOptions>(builder.Configuration.GetSection("TradingOptions"));
//builder.Services.AddScoped<IStocksService, StocksService>();
builder.Services.AddTransient<IStocksService, StocksService>();
builder.Services.AddTransient<IFinnhubService, FinnhubService>();
builder.Services.AddTransient<IStocksRepository, StocksRepository>();
builder.Services.AddTransient<IFinnhubRepository, FinnhubRepository>();
builder.Services.AddHttpClient();
builder.Services.AddDbContext<OrdersDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();
app.UseSerilogRequestLogging();
app.UseHttpLogging();

app.UseStaticFiles();
app.UseRouting();
app.MapControllers();

app.Run();

public partial class Program { } //make the auto-generated Program accessible programmatically

