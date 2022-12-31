using ServiceContracts;
using ServiceContracts.DTO;
using Services.ValidationHelpers;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class StocksService : IStocksService
    {
        private readonly List<BuyOrder> _buyOrders;
        private readonly List<SellOrder> _sellOrders;

        public StocksService()
        {
            _buyOrders = new List<BuyOrder>();
            _sellOrders = new List<SellOrder>();
        }
        

        Task<BuyOrderResponse> IStocksService.CreateBuyOrder(BuyOrderRequest? buyOrderRequest)
        {

            if (buyOrderRequest== null) throw new ArgumentNullException(nameof(buyOrderRequest)); 
            return Task.Run(() =>
            {             
                //Model validations
                ValidationHelper.ModelValidation(buyOrderRequest);
                BuyOrder buyOrder = buyOrderRequest.ToBuyOrder();
                buyOrder.BuyOrderID = Guid.NewGuid();
                _buyOrders.Add(buyOrder);
                return buyOrder.ToBuyOrderResponse();
            });
        }

        Task<SellOrderResponse> IStocksService.CreateSellOrder(SellOrderRequest? sellOrderRequest)
        {
            if (sellOrderRequest== null) throw new ArgumentNullException(nameof(sellOrderRequest));
            //Model validations            
            return Task.Run(() =>
            {
                //Model validations
                ValidationHelper.ModelValidation(sellOrderRequest);
                SellOrder sellOrder = sellOrderRequest.ToSellOrder();
                sellOrder.BuyOrderID = Guid.NewGuid();
                _sellOrders.Add(sellOrder);
                return sellOrder.ToSellOrderResponse();
            });
        }

        Task<List<BuyOrderResponse>> IStocksService.GetBuyOrders()
        {
            return Task.Run(() =>
            {
                List<BuyOrderResponse> buyOrderResponses = _buyOrders.Select(s => s.ToBuyOrderResponse()).ToList();
                return buyOrderResponses;
            });
        }

        Task<List<SellOrderResponse>> IStocksService.GetSellOrders()
        {
            return Task.Run(() =>
            {
                List<SellOrderResponse> sellOrderResponses = _sellOrders.Select(s => s.ToSellOrderResponse()).ToList();
                return sellOrderResponses;
            });
        }
    }
}
