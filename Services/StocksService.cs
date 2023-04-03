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

namespace Services
{
    public class StocksService : IStocksService
    {
        //private readonly List<BuyOrder> _buyOrders;
        //private readonly List<SellOrder> _sellOrders;
        //private readonly OrdersDbContext _db;
        private readonly IStocksRepository _stocksRepository;


        public StocksService(IStocksRepository stocksRepository)
        {
            //_buyOrders = new List<BuyOrder>();
            //_sellOrders = new List<SellOrder>();
            _stocksRepository = stocksRepository;
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
            List<BuyOrder> buyOrders = await _stocksRepository.GetBuyOrders();
            List<BuyOrderResponse> buyOrderResponses  = buyOrders.Select(s => s.ToBuyOrderResponse()).ToList();
            return buyOrderResponses;
            
        }

        async Task<List<SellOrderResponse>> IStocksService.GetSellOrders()
        {
            //var  sellOrders = await _db.SellOrders.ToListAsync();
            List<SellOrder> sellOrders = await _stocksRepository.GetSellOrders();
            List<SellOrderResponse> sellOrderResponses = sellOrders.Select(s => s.ToSellOrderResponse()).ToList();
            return sellOrderResponses;
            
        }
    }
}
