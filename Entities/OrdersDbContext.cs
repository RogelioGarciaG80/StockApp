using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace Entities
{
    public class OrdersDbContext : DbContext
    {
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<SellOrder> SellOrders { get; set; }


        public OrdersDbContext(DbContextOptions options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<BuyOrder>().ToTable("BuyOrder");
            modelBuilder.Entity<SellOrder>().ToTable("SellOrder");
            //Seed to BuyOrders
            modelBuilder.Entity<BuyOrder>().HasData(
                new BuyOrder() { BuyOrderID= Guid.Parse("b1cb2909-0265-4ab7-ad5c-6bdccdbdb191"),
                DateAndTimeOfOrder= new DateTime(2023,1,16),
                Price = 240.61,
                Quantity= 1,
                StockName ="Microsoft",
                StockSymbol="MSFT"
                },
                new BuyOrder()
                {
                    BuyOrderID = Guid.Parse("3c153be8-933f-4119-8890-fb47c24a0e86"),
                    DateAndTimeOfOrder = new DateTime(2023, 1, 16),
                    Price = 141.86,
                    Quantity = 1,
                    StockName = "Apple",
                    StockSymbol = "AAPL"
                }
                ,
                new BuyOrder()
                {
                    BuyOrderID = Guid.Parse("417e0310-ce0d-4c7f-a2e1-f8a02ddf8da8"),
                    DateAndTimeOfOrder = new DateTime(2023, 1, 16),
                    Price = 144.43,
                    Quantity = 1,
                    StockName = "Tesla",
                    StockSymbol = "TSLA"
                },
                 new BuyOrder()
                 {
                     BuyOrderID = Guid.Parse("3a09d4e8-97da-48e2-a2c7-2df312b0c851"),
                     DateAndTimeOfOrder = new DateTime(2023, 1, 16),
                     Price = 141.50,
                     Quantity = 1,
                     StockName = "META",
                     StockSymbol = "META"
                 }
                );

            modelBuilder.Entity<SellOrder>().HasData(
               new SellOrder()
               {
                   SellOrderID = Guid.Parse("2b8a325a-afaa-4b34-ac9b-5992b48ca897"),
                   StockName= "Netflix, Inc. ",
                   StockSymbol= "NFLX",
                   Price = 367.96,
                   Quantity = 2,
                   DateAndTimeOfOrder= new DateTime(2023,1,17)
               }
               ,
               new SellOrder()
               {
                   SellOrderID = Guid.Parse("a684ccee-322f-4b23-80e1-8ecd8c113300"),
                   StockName = "Costco Wholesale Corporation",
                   StockSymbol = "COST",
                   Price = 490.88,
                   Quantity = 1,
                   DateAndTimeOfOrder = new DateTime(2023, 1, 17)
               }

                );

        }
    }
}
