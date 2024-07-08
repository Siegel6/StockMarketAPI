// StockMarketAPI/Validators/StockRequestValidator.cs
using FluentValidation;

namespace StockMarketAPI.Validators
{
    public class StockRequestValidator : AbstractValidator<string>
    {
        public StockRequestValidator()
        {
            RuleFor(symbol => symbol).NotEmpty().WithMessage("Symbol is required.");
        }
    }
}
