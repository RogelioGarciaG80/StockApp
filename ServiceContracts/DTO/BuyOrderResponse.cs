using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ServiceContracts.DTO
{
    public class BuyOrderResponse
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

            if (obj.GetType() != typeof(BuyOrderResponse)) return false;

            BuyOrderResponse buyOrderResponse = (BuyOrderResponse)obj;

            return this.BuyOrderID == buyOrderResponse.BuyOrderID &&
                this.StockName == buyOrderResponse.StockName &&
                this.StockSymbol == buyOrderResponse.StockSymbol &&
                this.DateAndTimeOfOrder == buyOrderResponse.DateAndTimeOfOrder &&
                this.Quantity == buyOrderResponse.Quantity &&
                this.TradeAmount == buyOrderResponse.TradeAmount;

            //return base.Equals(obj);
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }

    public static class BuyOrdenExtensions
    {
        public static BuyOrderResponse ToBuyOrderResponse(this BuyOrder buyOrder)
        {
            return new BuyOrderResponse()
            {
                StockName = buyOrder.StockName,
                StockSymbol = buyOrder.StockSymbol,
                BuyOrderID= buyOrder.BuyOrderID,
                DateAndTimeOfOrder = buyOrder.DateAndTimeOfOrder,
                Quantity = buyOrder.Quantity,
                Price = buyOrder.Price,
                TradeAmount = buyOrder.Quantity * buyOrder.Price
            };
        }
    }
}
