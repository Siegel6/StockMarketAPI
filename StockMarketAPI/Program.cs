using FluentValidation.AspNetCore;
using StockMarketAPI.Core.Interfaces;
using StockMarketAPI.Core.Services;
using StockMarketAPI.Infrastructure.Repositories;

namespace StockMarketAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddControllers()
                .AddFluentValidation(fv => fv.RegisterValidatorsFromAssemblyContaining<Program>());
            builder.Services.AddApplicationInsightsTelemetry(builder.Configuration["ApplicationInsights:InstrumentationKey"]);
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Register dependencies
            builder.Services.AddHttpClient<IStockRepository, AlphaVantageStockRepository>();
            builder.Services.AddSingleton<IMarketRepository, NasdaqMarketRepository>();
            builder.Services.AddTransient<StockService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}