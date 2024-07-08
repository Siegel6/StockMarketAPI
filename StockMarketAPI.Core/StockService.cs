using StockMarketAPI.Core.Interfaces;
using StockMarketAPI.Core.Models;

namespace StockMarketAPI.Core.Services
{
    public class StockService
    {
        private readonly IStockRepository _stockRepository;
        private readonly IMarketRepository _marketRepository;

        public StockService(IStockRepository stockRepository, IMarketRepository marketRepository)
        {
            _stockRepository = stockRepository;
            _marketRepository = marketRepository;
        }

        public async Task<Stock> GetStockAsync(string symbol)
        {
            return await _stockRepository.GetStockAsync(symbol);
        }

        public async Task<Market> GetMarketAsync(string name)
        {
            return await _marketRepository.GetMarketAsync(name);
        }
    }
}