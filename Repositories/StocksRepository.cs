using Entities;
using Microsoft.EntityFrameworkCore;
using RepositoryContracts;
using System.Collections.Generic;

namespace Repositories
{
    public class StocksRepository : IStocksRepository
    {
        private readonly OrdersDbContext _db;

        public StocksRepository(OrdersDbContext db)
        {
            _db = db;
        }

        public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            _db.BuyOrders.Add(buyOrder);
            await _db.SaveChangesAsync();

            return buyOrder;
        }

        public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        {            
            _db.SellOrders.Add(sellOrder);
            await _db.SaveChangesAsync();

            return sellOrder;
        }

        public async Task<List<BuyOrder>> GetBuyOrders()
        {
            List<BuyOrder> buyOrders = await _db.BuyOrders
    .OrderByDescending(temp => temp.DateAndTimeOfOrder)
    .ToListAsync();

            return buyOrders;
        }

        public async Task<List<SellOrder>> GetSellOrders()
        {
            List<SellOrder> sellOrders = await _db.SellOrders
   .OrderByDescending(temp => temp.DateAndTimeOfOrder)
   .ToListAsync();
            return sellOrders;
        }
    }
}