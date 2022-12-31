using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class SellOrderResponse
    {
        public Guid BuyOrderID { get; set; }
        public string? StockSymbol { get; set; }
        public string? StockName { get; set; }
        public DateTime DateAndTimeOfOrder { get; set; }
        public uint Quantity { get; set; }
        public double Price { get; set; }
        public double TradeAmount { get; set; }

        public override string ToString()
        {
            //return base.ToString();
            return $"BuyOrder ID: {BuyOrderID}, Stock Symbol: {StockSymbol}, Stock Name: {StockName}, Date and Time Of Order: {DateAndTimeOfOrder}, Quantity {Quantity}, Price: {Price}, TradeAmount: {TradeAmount}  ";
        }

        public override bool Equals(object? obj)
        {
            if (obj==null) return false;

            if (obj.GetType() != typeof(SellOrderResponse)) return false;

            SellOrderResponse sellOrderResponse = (SellOrderResponse)obj;

            return this.BuyOrderID == sellOrderResponse.BuyOrderID &&
                this.StockName == sellOrderResponse.StockName &&
                this.StockSymbol == sellOrderResponse.StockSymbol &&
                this.DateAndTimeOfOrder == sellOrderResponse.DateAndTimeOfOrder &&
                this.Quantity == sellOrderResponse.Quantity &&
                this.TradeAmount == sellOrderResponse.TradeAmount;

            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class SellOrdenExtensions
    {
        public static SellOrderResponse ToSellOrderResponse(this SellOrder sellOrder)
        {
            return new SellOrderResponse()
            {
                StockName = sellOrder.StockName,
                StockSymbol = sellOrder.StockSymbol,
                BuyOrderID= sellOrder.BuyOrderID,
                DateAndTimeOfOrder = sellOrder.DateAndTimeOfOrder,
                Quantity = sellOrder.Quantity,
                Price = sellOrder.Price,
                TradeAmount = sellOrder.Quantity * sellOrder.Price
            };
        }
    }
}
