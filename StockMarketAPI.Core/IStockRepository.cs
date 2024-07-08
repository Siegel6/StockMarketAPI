// StockMarketAPI.Core/Interfaces/IStockRepository.cs
using StockMarketAPI.Core.Models;

namespace StockMarketAPI.Core.Interfaces
{
    public interface IStockRepository
    {
        Task<Stock> GetStockAsync(string symbol);
    }
}
