// StockMarketAPI.Infrastructure/Repositories/NasdaqMarketRepository.cs
using StockMarketAPI.Core.Interfaces;
using StockMarketAPI.Core.Models;
using System.Net.Http.Json;

namespace StockMarketAPI.Infrastructure.Repositories
{
    public class NasdaqMarketRepository : IMarketRepository
    {
        private readonly HttpClient _httpClient;

        public NasdaqMarketRepository(HttpClient httpClient)
        {
            _httpClient = httpClient ?? throw new ArgumentNullException(nameof(httpClient));
            _httpClient.BaseAddress = new Uri("https://data.nasdaq.com/api/v3/");
            _httpClient.DefaultRequestHeaders.Add("Accept", "application/json");
        }

        public async Task<Market> GetMarketAsync(string name)
        {
            try
            {

                var response = await _httpClient.GetFromJsonAsync<NasdaqMarketResponse>($"markets/{name}?apikey=YOUR_API_KEY_SRY_THIS_ONE_WAS_MORE_ANNOYING");

                if (response != null && response.Data != null)
                {
                    return new Market
                    {
                        Name = response.Data.Name,
                        Country = response.Data.Country
                    };
                }
                else
                {
                    return null;
                }
            }
            catch (HttpRequestException)
            {

                throw;
            }
        }


        private class NasdaqMarketResponse
        {
            public NasdaqMarketData Data { get; set; }
        }

        private class NasdaqMarketData
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }
    }
}
