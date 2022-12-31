using ServiceContracts;
using ServiceContracts.DTO;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Xunit.Abstractions;

namespace StocksTest
{
    public class StocksServiceTest
    {
        private readonly IStocksService _stocksService;
        private readonly ITestOutputHelper _testOutputHelper;
        public StocksServiceTest(ITestOutputHelper testOutputHelper) {
            _stocksService = new StocksService();
            _testOutputHelper = testOutputHelper;
        }

        #region CreateBuyOrder
        //When argument BuyOrderRequest is null, it should throw null argument
        [Fact]
        public void CreateBuyOrder_IsNull()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = null;
            //Fact
            Assert.ThrowsAsync<ArgumentNullException>( ()=>_stocksService.CreateBuyOrder(buyOrderRequest));
        }
        //When Quantity is 0, it should throw argument exception
        [Fact]
        public void CreateBuyOrder_QuantityIsZero()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                Quantity = 0
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }
        //When Quantity is 100001 , it should throw argument exception
        [Fact]
        public void CreateBuyOrder_QuantityIs100001()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                Quantity = 100001
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }
        //When Price is 0, it should throw argument exception
        [Fact]
        public void CreateBuyOrder_PriceIsZero()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                Price = 0
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }
        //When Price is 100001 , it should throw argument exception
        [Fact]
        public void CreateBuyOrder_PriceIs100001()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
               Price = 100001
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }
        //When dateAndTimeOfOrder is minus  "1999-12-31" 
        [Fact]
        public void CreateBuyOrder_dateAndTimeOfOrder_1999()
        {
            //Arrange
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                DateAndTimeOfOrder = new DateTime(1999,12,31)
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateBuyOrder(buyOrderRequest));
        }
        [Fact]
        public async Task CreateBuyOrder_ValidAsync()
        {
            BuyOrderRequest buyOrderRequest = new BuyOrderRequest()
            {
                StockSymbol = "APPL",
                StockName = "Apple",
                DateAndTimeOfOrder = new DateTime(2013,12,10),
                Quantity = 1,
                Price = 129.13
            };
            BuyOrderResponse ?buyOrderResponse = await _stocksService.CreateBuyOrder(buyOrderRequest);
            Assert.True(buyOrderResponse.BuyOrderID != Guid.Empty);
        }
        #endregion
        #region CreateSellOrder
        //When argument BuyOrderRequest is null, it should throw null argument
        [Fact]
        public void CreateSellOrder_IsNull()
        {
            //Arrange
            SellOrderRequest buySellRequest = null;
            //Fact
            Assert.ThrowsAsync<ArgumentNullException>(() => _stocksService.CreateSellOrder(buySellRequest));
        }
        //When Quantity is 0, it should throw argument exception
        [Fact]
        public void CreateSellOrder_QuantityIsZero()
        {
            //Arrange
            SellOrderRequest buySellRequest = new SellOrderRequest()
            {
                Quantity = 0
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateSellOrder(buySellRequest));
        }
        //When Quantity is 100001 , it should throw argument exception
        [Fact]
        public void CreateSellOrder_QuantityIs100001()
        {
            //Arrange
            SellOrderRequest buySellRequest = new SellOrderRequest()
            {
                Quantity = 100001
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateSellOrder(buySellRequest));
        }
        //When Price is 0, it should throw argument exception
        [Fact]
        public void CreateSellOrder_PriceIsZero()
        {
            //Arrange
            SellOrderRequest buySellRequest = new SellOrderRequest()
            {
                Price = 0
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateSellOrder(buySellRequest));
        }
        //When Price is 100001 , it should throw argument exception
        [Fact]
        public void CreateSellOrder_PriceIs100001()
        {
            //Arrange
            SellOrderRequest buyCreateRequest = new SellOrderRequest()
            {
                Price = 100001
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateSellOrder(buyCreateRequest));
        }
        //When dateAndTimeOfOrder is minus  "1999-12-31" 
        [Fact]
        public void CreateSellOrder_dateAndTimeOfOrder_1999()
        {
            //Arrange
            SellOrderRequest buySellRequest = new SellOrderRequest()
            {
                DateAndTimeOfOrder = new DateTime(1999, 12, 31)
            };
            //Fact
            Assert.ThrowsAsync<ArgumentException>(() => _stocksService.CreateSellOrder(buySellRequest));
        }
        [Fact]
        public async Task CreateSellOrder_ValidAsync()
        {
            SellOrderRequest buySellRequest = new SellOrderRequest()
            {
                StockSymbol = "APPL",
                StockName = "Apple",
                DateAndTimeOfOrder = new DateTime(2013, 12, 10),
                Quantity = 1,
                Price = 129.13
            };
            SellOrderResponse? buyOrderResponse = await _stocksService.CreateSellOrder(buySellRequest);
            Assert.True(buyOrderResponse.BuyOrderID != Guid.Empty);
        }
        #endregion
        #region GetAllBuyOrders

        [Fact]
        public async void GetAllBuyOrders_IsEmpty()
        {
            List<BuyOrderResponse> buyOrderResponses = await this._stocksService.GetBuyOrders();
            Assert.Empty(buyOrderResponses);
        }

        [Fact]
        public async void GetAllBuyOrders_FewOrders()
        {
            List<BuyOrderRequest> buyOrderAddRequests = new List<BuyOrderRequest>()
            {
                new BuyOrderRequest()
                {
                    StockSymbol = "VOO",
                    StockName = "Vangard S&P 500",
                    DateAndTimeOfOrder = new DateTime(2013,12,10),
                    Quantity = 1,
                    Price = 129.13
                },
                new BuyOrderRequest()
                {
                    StockSymbol = "VNQ",
                    StockName = "Vangard Real State",
                    DateAndTimeOfOrder = new DateTime(2013,12,10),
                    Quantity = 1,
                    Price = 129.13
                },
                new BuyOrderRequest()
                {
                    StockSymbol = "VEA",
                    StockName = "Vangard Country Developement",
                    DateAndTimeOfOrder = new DateTime(2013,12,10),
                    Quantity = 1,
                    Price = 129.13
                }
            };
            List<BuyOrderResponse> list_from_add_buyOrder = new List<BuyOrderResponse>();
            foreach (BuyOrderRequest buyOrderAddRequest in buyOrderAddRequests)
            {
                list_from_add_buyOrder.Add(await _stocksService.CreateBuyOrder(buyOrderAddRequest));
            }
            _testOutputHelper.WriteLine("Expected: ");
            foreach (BuyOrderResponse buyOrderAddRequestTest in list_from_add_buyOrder)
            {
                _testOutputHelper.WriteLine(buyOrderAddRequestTest.ToString());
            }
            List<BuyOrderResponse> actualBuyOrderResponseList = await _stocksService.GetBuyOrders();

            _testOutputHelper.WriteLine("Actual: ");

            foreach (BuyOrderResponse buyOrderAddRequestActual in actualBuyOrderResponseList)
            {
                _testOutputHelper.WriteLine(buyOrderAddRequestActual.ToString());
            }
            //read each element
            foreach (var expected in list_from_add_buyOrder)
            {
                Assert.Contains(expected, actualBuyOrderResponseList);
            }
        }
        #endregion
        #region GetAllSellOrders
        [Fact]
        public async void GetAllSellOrders_IsEmpty()
        {
            List<SellOrderResponse> sellOrderResponses = await this._stocksService.GetSellOrders();
            Assert.Empty(sellOrderResponses);
        }

        [Fact]
        public async void GetAllSellOrders_FewOrders()
        {
            List<SellOrderRequest> sellOrderAddRequests = new List<SellOrderRequest>()
            {
                new SellOrderRequest()
                {
                    StockSymbol = "FMTY",
                    StockName = "Fibra Monterrey",
                    DateAndTimeOfOrder = new DateTime(2013,12,10),
                    Quantity = 1,
                    Price = 12.3
                },
                new SellOrderRequest()
                {
                    StockSymbol = "FUNO",
                    StockName = "Funo",
                    DateAndTimeOfOrder = new DateTime(2013,12,10),
                    Quantity = 1,
                    Price = 23.10
                },
                new SellOrderRequest()
                {
                    StockSymbol = "DANHOS",
                    StockName = "Danhos",
                    DateAndTimeOfOrder = new DateTime(2013,12,10),
                    Quantity = 1,
                    Price = 26.01
                }
            };
            List<SellOrderResponse> list_from_add_sellOrder = new List<SellOrderResponse>();
            foreach (SellOrderRequest sellOrderAddRequest in sellOrderAddRequests)
            {
                list_from_add_sellOrder.Add(await _stocksService.CreateSellOrder(sellOrderAddRequest));
            }
            _testOutputHelper.WriteLine("Expected: ");
            foreach (SellOrderResponse sellOrderAddRequestTest in list_from_add_sellOrder)
            {
                _testOutputHelper.WriteLine(sellOrderAddRequestTest.ToString());
            }
            List<SellOrderResponse> actualSellOrderResponseList = await _stocksService.GetSellOrders();

            _testOutputHelper.WriteLine("Actual: ");

            foreach (SellOrderResponse sellOrderAddRequestActual in actualSellOrderResponseList)
            {
                _testOutputHelper.WriteLine(sellOrderAddRequestActual.ToString());
            }
            //read each element
            foreach (var expected in list_from_add_sellOrder)
            {
                Assert.Contains(expected, actualSellOrderResponseList);
            }
        }


        #endregion
    }
}
