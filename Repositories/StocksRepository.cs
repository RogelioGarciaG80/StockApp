using Entities;
using RepositoryContracts;

namespace Repositories
{
    public class StocksRepository : IStocksRepository
    {
        private readonly ApplicationDBContext _db;
        public async Task<BuyOrder> CreateBuyOrder(BuyOrder buyOrder)
        {
            throw new NotImplementedException();
        }

        public async Task<SellOrder> CreateSellOrder(SellOrder sellOrder)
        {
            throw new NotImplementedException();
        }

        public async Task<List<BuyOrder>> GetBuyOrders()
        {
            throw new NotImplementedException();
        }

        public async Task<List<SellOrder>> GetSellOrders()
        {
            throw new NotImplementedException();
        }
    }
}