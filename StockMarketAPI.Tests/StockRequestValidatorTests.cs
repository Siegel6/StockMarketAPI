// StockMarketAPI.Tests/Validation/StockRequestValidatorTests.cs
using FluentValidation.TestHelper;
using StockMarketAPI.Validators;

namespace StockMarketAPI.Tests
{
    public class StockRequestValidatorTests
    {
        private readonly StockRequestValidator _validator;

        public StockRequestValidatorTests()
        {
            _validator = new StockRequestValidator();
        }

        [Theory]
        [InlineData("")]
        [InlineData(null)]
        public void Validate_SymbolNullOrEmpty_ShouldHaveValidationError(string symbol)
        {
            // Act
            var result = _validator.TestValidate(symbol);

            // Assert
            result.ShouldHaveValidationErrorFor(s => s);
        }

        [Fact]
        public void Validate_ValidSymbol_ShouldNotHaveValidationError()
        {
            // Act
            var result = _validator.TestValidate("AAPL");

            // Assert
            result.ShouldNotHaveValidationErrorFor(s => s);
        }
    }
}