using Entities;
using ServiceContracts.CustomValidators;
using System;
using System.ComponentModel.DataAnnotations;

namespace ServiceContracts.DTO
{
    public class SellOrderRequest
    {
        [Required(ErrorMessage = "The stock symbol can't be empty")]
        public string? StockSymbol { get; set; }
        [Required(ErrorMessage = "The stock symbol can't be empty")]
        public string? StockName { get; set; }
        [MinimumYearValidatorAttribute]
        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000, ErrorMessage = "Value should be between 1 and 100000")]
        public uint Quantity { get; set; }
        [Range(1, 100000, ErrorMessage = "Value should be between 1 and 100000")]
        public double Price { get; set; }

        public SellOrder ToSellOrder()
        {
            return new SellOrder()
            {
                StockSymbol = StockSymbol,
                StockName = StockName,
                DateAndTimeOfOrder = DateAndTimeOfOrder,
                Quantity = Quantity,
                Price = Price
            };
        }
    }
}
