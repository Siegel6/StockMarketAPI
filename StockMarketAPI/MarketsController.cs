// StockMarketAPI/Controllers/MarketsController.cs
using Microsoft.AspNetCore.Mvc;
using StockMarketAPI.Core.Services;

namespace StockMarketAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MarketsController : ControllerBase
    {
        private readonly StockService _stockService;

        public MarketsController(StockService stockService)
        {
            _stockService = stockService;
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> GetMarket(string name)
        {
            var market = await _stockService.GetMarketAsync(name);
            if (market == null)
            {
                return NotFound();
            }
            return Ok(market);
        }
    }
}
