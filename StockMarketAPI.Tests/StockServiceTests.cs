// StockMarketAPI.Tests/Services/StockServiceTests.cs
using Moq;
using StockMarketAPI.Core.Interfaces;
using StockMarketAPI.Core.Models;
using StockMarketAPI.Core.Services;

namespace StockMarketAPI.Tests
{
    public class StockServiceTests
    {
        private readonly Mock<IStockRepository> _stockRepoMock;
        private readonly Mock<IMarketRepository> _marketRepoMock;
        private readonly StockService _stockService;

        public StockServiceTests()
        {
            _stockRepoMock = new Mock<IStockRepository>();
            _marketRepoMock = new Mock<IMarketRepository>();
            _stockService = new StockService(_stockRepoMock.Object, _marketRepoMock.Object);
        }

        [Fact]
        public async Task GetStockAsync_ReturnsStock()
        {
            // Arrange
            var symbol = "AAPL";
            var expectedStock = new Stock { Symbol = symbol, CompanyName = "Apple Inc.", Price = 150.00M };
            _stockRepoMock.Setup(repo => repo.GetStockAsync(symbol)).ReturnsAsync(expectedStock);

            // Act
            var result = await _stockService.GetStockAsync(symbol);

            // Assert
            Assert.Equal(expectedStock, result);
        }

        [Fact]
        public async Task GetMarketAsync_ReturnsMarket()
        {
            // Arrange
            var marketName = "Nasdaq";
            var expectedMarket = new Market { Name = marketName, Country = "USA" };
            _marketRepoMock.Setup(repo => repo.GetMarketAsync(marketName)).ReturnsAsync(expectedMarket);

            // Act
            var result = await _stockService.GetMarketAsync(marketName);

            // Assert
            Assert.Equal(expectedMarket, result);
        }
    }
}