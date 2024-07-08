// StockMarketAPI.Core/Models/Stock.cs
namespace StockMarketAPI.Core.Models
{
    public class Stock
    {
        public string Symbol { get; set; }
        public string CompanyName { get; set; }
        public decimal Price { get; set; }
    }
}
