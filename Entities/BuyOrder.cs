using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class BuyOrder
    {
        [Key]
        public Guid BuyOrderID { get; set; }
        [Required(ErrorMessage = "StockSymbol can't be blank")]

        [StringLength(100)]
        public string? StockSymbol { get; set; }
        [Required(ErrorMessage = "StockName can't be blank")]

        [StringLength(200)]
        public string? StockName { get; set; }

        public DateTime DateAndTimeOfOrder { get; set; }

        [Range(1, 100000, ErrorMessage = "The range is 1 to 100000")]
        public uint Quantity { get; set; }
        [Range(1, 100000, ErrorMessage = "The range is 1 to 100000")]
        public double Price { get; set; }
    }
}