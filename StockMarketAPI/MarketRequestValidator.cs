// StockMarketAPI/Validators/MarketRequestValidator.cs
using FluentValidation;

namespace StockMarketAPI.Validators
{
    public class MarketRequestValidator : AbstractValidator<string>
    {
        public MarketRequestValidator()
        {
            RuleFor(name => name).NotEmpty().WithMessage("Market name is required.");
        }
    }
}
