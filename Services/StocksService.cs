using ServiceContracts;
using ServiceContracts.DTO;
using Services.ValidationHelpers;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using Microsoft.Extensions.Logging;
using Serilog;
using SerilogTimings;

namespace Services
{
    public class StocksService : IStocksService
    {
        //private readonly List<BuyOrder> _buyOrders;
        //private readonly List<SellOrder> _sellOrders;
        //private readonly OrdersDbContext _db;
        private readonly IStocksRepository _stocksRepository;
        private readonly ILogger<StocksService> _logger;
        private readonly IDiagnosticContext _diagnosticContext;


        public StocksService(IStocksRepository stocksRepository,ILogger<StocksService> logger,IDiagnosticContext diagnosticContext)
        {
            //_buyOrders = new List<BuyOrder>();
            //_sellOrders = new List<SellOrder>();
            _stocksRepository = stocksRepository;
            _logger = logger;
            _diagnosticContext = diagnosticContext;
        }
        

        async Task<BuyOrderResponse> IStocksService.CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {

            if (buyOrderRequest== null) throw new ArgumentNullException(nameof(buyOrderRequest));                          
                //Model validations
                ValidationHelper.ModelValidation(buyOrderRequest);
                BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
                buyOrder.BuyOrderID = Guid.NewGuid();
                //_buyOrders.Add(buyOrder);
                //await _db.BuyOrders.AddAsync(buyOrder);
                //await _db.SaveChangesAsync();
                BuyOrder buyOrderFromRepo = await _stocksRepository.CreateBuyOrder(buyOrder);
                return buyOrder.ToBuyOrderResponse();            
        }

        async Task<SellOrderResponse> IStocksService.CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest== null) throw new ArgumentNullException(nameof(sellOrderRequest));
                       
                //Model validations
                ValidationHelper.ModelValidation(sellOrderRequest);
                SellOrder sellOrder = sellOrderRequest.ToSellOrder();
                sellOrder.SellOrderID = Guid.NewGuid();
            //await _db.SellOrders.AddAsync(sellOrder);
            //await _db.SaveChangesAsync();
            SellOrder SellOrderFromRepo = await _stocksRepository.CreateSellOrder(sellOrder);
            return sellOrder.ToSellOrderResponse();           
        }

        async Task<List<BuyOrderResponse>> IStocksService.GetBuyOrders()
        {

            //var buyOrders  = await _db.BuyOrders.ToListAsync();
            List<BuyOrderResponse> buyOrderResponses;
            using (Operation.Time("Timee for GetBuyOrders"))
            {
                List<BuyOrder> buyOrders = await _stocksRepository.GetBuyOrders();
                buyOrderResponses = buyOrders.Select(s => s.ToBuyOrderResponse()).ToList();
            }
            return buyOrderResponses;
            
        }

        async Task<List<SellOrderResponse>> IStocksService.GetSellOrders()
        {
            //var  sellOrders = await _db.SellOrders.ToListAsync();
            List<SellOrderResponse> sellOrderResponses;
            using (Operation.Time("Timee for GetSellOrders"))
            {
                List<SellOrder> sellOrders = await _stocksRepository.GetSellOrders();
                sellOrderResponses = sellOrders.Select(s => s.ToSellOrderResponse()).ToList();
            }
            return sellOrderResponses;
            
        }
    }
}
