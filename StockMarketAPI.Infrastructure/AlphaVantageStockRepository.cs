// StockMarketAPI.Infrastructure/Repositories/AlphaVantageStockRepository.cs
using Polly;
using Polly.Extensions.Http;
using StockMarketAPI.Core.Interfaces;
using StockMarketAPI.Core.Models;

namespace StockMarketAPI.Infrastructure.Repositories
{
    public class AlphaVantageStockRepository : IStockRepository
    {
        private readonly HttpClient _httpClient;

        public AlphaVantageStockRepository(HttpClient httpClient)
        {
            _httpClient = httpClient;
            var retryPolicy = HttpPolicyExtensions
                .HandleTransientHttpError()
                .OrResult(msg => msg.StatusCode == System.Net.HttpStatusCode.NotFound)
                .RetryAsync(3);

            _httpClient.DefaultRequestHeaders.Add("RetryPolicy", retryPolicy.ToString());
        }

        public async Task<Stock> GetStockAsync(string symbol)
        {
            var response = await _httpClient.GetAsync($"https://www.alphavantage.co/query?function=TIME_SERIES_DAILY&symbol={symbol}&apikey=D8AW8PNMVQSJISLP");
            // Handle response and parse JSON
            // For brevity, assume we deserialize directly to Stock. Adjust according to actual response.
            var stock = new Stock { Symbol = symbol, CompanyName = "Company XYZ", Price = 100.00M }; // Placeholder
            return stock;
        }
    }
}
