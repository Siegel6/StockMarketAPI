// StockMarketAPI/Controllers/StocksController.cs
using Microsoft.AspNetCore.Mvc;
using StockMarketAPI.Core.Services;

namespace StockMarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StocksController : ControllerBase
    {
        private readonly StockService _stockService;

        public StocksController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{symbol}")]
        public async Task<IActionResult> GetStock(string symbol)
        {
            var stock = await _stockService.GetStockAsync(symbol);
            if (stock == null)
            {
                return NotFound();
            }
            return Ok(stock);
        }

    }
}
