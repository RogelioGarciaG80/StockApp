using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace StocksApp.Controllers
{
    public class HomeController : Controller
    {        
        private readonly TradingOptions _tradingOptions;
        public HomeController(
                              IOptions<TradingOptions> tradingOptions)
        {   
            _tradingOptions = tradingOptions.Value;
        }

        
       public IActionResult Index()
        {
         
            string? DefaultStockSymbol = _tradingOptions.DefaultStockSymbol; 
            return View();
        }
    }
}
