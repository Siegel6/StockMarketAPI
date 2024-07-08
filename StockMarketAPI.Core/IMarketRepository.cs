// StockMarketAPI.Core/Interfaces/IMarketRepository.cs
using StockMarketAPI.Core.Models;

namespace StockMarketAPI.Core.Interfaces
{
    public interface IMarketRepository
    {
        Task<Market> GetMarketAsync(string name);
    }
}
